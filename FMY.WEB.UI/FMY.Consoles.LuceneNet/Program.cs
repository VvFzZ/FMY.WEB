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

namespace FMY.Consoles.LuceneNet
{
    class Program
    {
        static string contentStr =

        #region MyRegion
            @"大家好，今年5月5日，是诞辰200周年。马克思是德国人，1818年出生在德国特里尔城，马克思是伟人，是马克思主义的创立者，他为什么能创立马克思主义理论，能够创立科学社会主义的学说？除了当时的社会历史条件之外，马克思个人所具有的特殊的优秀品质非常重要。
他作为革命家，作为马克思主义创立者，具有革命精神、批判精神、创造精神、求实精神，包括非常勤奋刻苦的精神，这样一些优秀品质。从他的勤奋刻苦来看，我们讲一个小故事，我们都知道《资本论》是马克思主义的经典著作，这部经典著作耗费了马克思的大量心血。他为了写作《资本论》，研究资本主义的经济规律，长期泡在英国伦敦大英博物馆，查阅各种资料，进行研究思考。他有一个习惯，一边看资料一边思索的时候，右脚经常来回地滑动，结果资本论写成之日，右脚滑动的地方，是石头的地面，都滑动出一条深沟，马克思勤奋刻苦的精神由此可见一斑。他用他的勤奋刻苦研究人类思想史上一切有益的成果，进行自己独特伟大的创造，创立了马克思主义，创立了科学社会主义理论。这个理论这个学说的出现，改变了人类历史的进程。
　　中国特色社会主义的伟大成功就是马克思主义、科学社会主义理论在中国伟大实践的成功。近代以来，中华民族、中国社会、中国人民命运的改变，我们党领导的中国革命、建设、改革的伟大成就，归根到底，都是因为我们有马克思主义中国化成果这个科学理论的指导。马克思主义中国化时代化的最新成果就是习近平新时代中国特色社会主义思想，中国人民要把中国特色社会主义事业推向前进，要把我们国家建成富强、民主、文明、和谐、美丽的社会主义现代化强国，要实现中华民族伟大复兴的中国梦，我们就必须要用习近平新时代中国特色社会主义思想这个马克思主义中国化最新成果，来武装全党。";
        #endregion

        private static Program instance = new Program();
        static void Main(string[] args)
        {
            string indexPath = @"E:\lucene\index";
            //WriteIndex(indexPath);
            ReadIndex(indexPath);
            Console.ReadKey();
        }

        public static void WriteIndex(string indexPath)
        {
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NativeFSLockFactory());
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
            doc.Add(new Field("title", "社会主义", Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("content", contentStr, Field.Store.NO, Field.Index.ANALYZED));
            writer.AddDocument(doc);

            writer.Dispose();
            directory.Dispose();
        }

        public static void ReadIndex(string indexPath)
        {
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NativeFSLockFactory());
            IndexReader reader = IndexReader.Open(directory, false);
            IndexSearcher searcher = new IndexSearcher(reader);

            var query = new PhraseQuery();
            query.Add(new Term("title", "马克思"));           
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
    }
}
