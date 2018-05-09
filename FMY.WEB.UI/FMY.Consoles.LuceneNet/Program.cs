using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Search;
using Lucene.Net.Analysis.Tokenattributes;

namespace FMY.Consoles.LuceneNet
{
    class Program
    {
        static string contentStr =

        #region MyRegion
            @"
市政工程资质的审批流程是什么，对于建筑企业来说，办理市政资质关心的问题可能是市政资质的办理流程，市政资质办理并不简单，但涉及到市政资质升级和资质增项时，关于资质审批的流程和时间可能是建筑企业更为关注的问题，接下来资质管家小编将说一下市政工程资质审批流程和时间。2018年市政工程资质审批程序：

　　1.建筑企业到工商行政管理部门办理注销登记手续，领取企业法人营业执照;

　　2.到企业所在城市设立行政主管部门交企业资质申请表，填写规则，编制申请标准;

　　3.向各县(市)报告建立初步审查的行政部门，并检查原始信息的提交情况(郊区企业间接向市报告建立行政主管部门审核并核对原始信息的提交情况);

　　4.对申请资质的建筑企业进行网上公示，公告不得少于十日;

　　5.市设立行政管理部门组织专家进行资质审查;

　　6.负责指导审批;

　　7.将企业的申请材料提交省设立办公室。

　　2018年市政工程资质审批时间：

　　市政工程项目总承包资质要求在互联网上公示10日。所需的步骤是：准备材料，审查，批准，报告，公示和领取证书。最初申请市政工程资质要从三级资质开始申请，建筑公司可以通过市政资质升级扩大业务范围。

　　以上就是市政工程资质的审批流程和时间，在办理市政工程资质时，企业要了解市政资质的相关办理流程，对于资质办理的材料方面的要求需要满足资质标准的相关规定，如果在市政工程资质办理上还有其他疑问欢迎咨询资质管家。
";
        #endregion

        private static Program instance = new Program();
        static void Main(string[] args)
        {
            string indexPath = @"E:\lucene\index";
            ReusableTokenStreamTest();
            //WriteIndex(indexPath);
            //ReadIndex(indexPath);
            Console.ReadKey();
        }

        public static void WriteIndex(string indexPath)
        {
            #region FSDirectory
            //例如Directory定义了索引文件的存储结构，
            //FSDirectory为存储在文件中的索引，
            //RAMDirectory为存储在内存中的索引，
            //MmapDirectory为使用内存映射的索引。 
            #endregion
            FSDirectory directory = Lucene.Net.Store.FSDirectory.Open(new DirectoryInfo(indexPath), new NativeFSLockFactory());
            bool existsDirectory = IndexReader.IndexExists(directory);

            if (existsDirectory && IndexWriter.IsLocked(directory))
            {
                IndexWriter.Unlock(directory);
            }

            IndexWriter writer = new IndexWriter(directory
                , new PanGuAnalyzer()
                , !existsDirectory
                , IndexWriter.MaxFieldLength.UNLIMITED);

            Document doc = new Document();
            doc.Add(new Field("title", "市政工程资质审批流程和时间", Field.Store.YES, Field.Index.ANALYZED));
            doc.Add(new Field("content", contentStr, Field.Store.YES, Field.Index.ANALYZED));
            writer.AddDocument(doc);
            //优化主要是将多个segment合并到一个，有利于提高索引速度 (合并影响性能，定时，定量合并)
            //writer.Optimize();
            writer.Dispose();
            directory.Dispose();
        }

        public static void ReadIndex(string indexPath)
        {
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NativeFSLockFactory());
            IndexReader reader = IndexReader.Open(directory, true);
            IndexSearcher searcher = new IndexSearcher(reader);

            PhraseQuery query = new PhraseQuery();
            query.Add(new Term("title", "工程"));
            TopScoreDocCollector collector = TopScoreDocCollector.Create(1000, true);
            searcher.Search(query, null, collector);
            ScoreDoc[] docs = collector.TopDocs(0, collector.TotalHits).ScoreDocs;
            for (int i = 0; i < docs.Length; i++)
            {
                int docId = docs[i].Doc;
                Document d = searcher.Doc(docId);
                Console.WriteLine(d.Get("title"));
            }
        }

        public static void ReusableTokenStreamTest()
        {
            string testwords = "我是中国人，I can speak chinese!";

            //SimpleAnalyzer simple = new SimpleAnalyzer();
            StandardAnalyzer standard = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            TokenStream ts = standard.ReusableTokenStream("content", new StringReader(testwords));            
            
            while (ts.IncrementToken())
            {
                ITermAttribute term = ts.GetAttribute<ITermAttribute>();
                Console.WriteLine(term.Term);
            }

            ts.Dispose();
        }

        #region Query
        public static Query GetBasicQuery()
        {
            Term t = new Term("content", " lucene");
            Query query = new TermQuery(t);
            return query;
        }

        public static Query GetBooleanQuery()
        {
            TermQuery termQuery1 = new TermQuery(new Term("title", "java"));
            TermQuery termQuery2 = new TermQuery(new Term("title", "perl"));
            BooleanQuery booleanQuery = new BooleanQuery();
            booleanQuery.Add(termQuery1, Occur.SHOULD);
            booleanQuery.Add(termQuery2, Occur.SHOULD);
            return booleanQuery;
        }

        public static Query GetWildcardQuery()
        {
            Query query = new WildcardQuery(new Term("content", "use*"));
            return query;
        }

        public static Query GetPhraseQuery()
        {
            //你可能对中日关系比较感兴趣，
            //想查找‘中’和‘日’挨得比较近（5个字的距离内）的文章，超过这个距离的不予考虑
            PhraseQuery query = new PhraseQuery();
            query.Slop = 5;// (5);
            query.Add(new Term("content ", "中"));
            query.Add(new Term("content", "日"));
            return query;
        }

        public static Query GetPrefixQuery()
        {
            PrefixQuery query = new PrefixQuery(new Term("content ", "中"));
            return query;
        }

        public static Query GetFuzzyQuery()
        {
            //想搜索跟‘wuzza’相似的词语   可能得到‘fuzzy’和‘wuzzy’。 
            Query query = new FuzzyQuery(new Term("content", "wuzza"));
            return query;
        }

        public static Query GetRangeQuery()
        {
            //RangeQuery query = new RangeQuery(new Term(“time”, “20060101”), new Term(“time”, “20060130”), true);

            return null;
        }
        #endregion
    }
}
