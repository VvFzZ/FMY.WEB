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
        private static Program instance = new Program();
        static void Main(string[] args)
        {
            string indexPath = @"E:\lucene\index";
            WriteIndex(indexPath);
            ReadIndex(indexPath);
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
            doc.Add(new Field("title", "title", Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("content", "你好吗小白", Field.Store.YES, Field.Index.ANALYZED));
            writer.AddDocument(doc);

            writer.Dispose();
            directory.Dispose();
        }

        public static void ReadIndex(string indexPath)
        {
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NativeFSLockFactory());
            IndexReader reader = IndexReader.Open(directory, true);
            IndexSearcher searcher = new IndexSearcher(reader);

            var query = new PhraseQuery();
            //query.Add(new Term("content", "小白"));
            TopScoreDocCollector collector = TopScoreDocCollector.Create(10, true);
            searcher.Search(query, null, collector);
            ScoreDoc[] docs = collector.TopDocs(0, collector.TotalHits).ScoreDocs;
            for (int i = 0; i < docs.Length; i++)
            {
                int docId = docs[i].Doc;

                Document d = searcher.Doc(docId);
                Console.WriteLine(d.Get("content"));
            }
        }
    }


}
