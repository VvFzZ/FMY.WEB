using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FMY.Consoles.LuceneNet
{
    public class IndexManager
    {
        private static IndexManager instance = new IndexManager();
        //所有的地方要对索引库进行修改都通过IndexManager，所以要单例
        //因为同时只能有一个在写索引库，所以由“消费者”来进行写
        //别的地方想写索引库要请求“消费者”来进行写AddArticle
        private IndexManager()
        {

        }

        /// <summary>
        /// 启动消费者线程
        /// </summary>
        public void Start()
        {
            Thread threadIndex = new Thread(Index);
            threadIndex.IsBackground = true;
            threadIndex.Start();
        }

        private void Index()
        {
            while (true)
            {
                //防止空转造成cpu占用率过高
                if (jobs.Count <= 0)
                {
                    //logger.Debug("没有任务，再睡会！");
                    Thread.Sleep(5 * 1000);
                    continue;
                }

                //为什么每次循环都要打开、关闭索引库。因为关闭索引库以后才会把写入的数据提交到索引库中。也可以每次操作都“提交”（参考Lucene.net文档）

                string indexPath = "c:/cmsindex";
                FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NativeFSLockFactory());
                bool isUpdate = IndexReader.IndexExists(directory);
                //logger.Debug("索引库存在状态" + isUpdate);
                if (isUpdate)
                {
                    //如果索引目录被锁定（比如索引过程中程序异常退出），则首先解锁
                    if (IndexWriter.IsLocked(directory))
                    {
                        //logger.Debug("开始解锁索引库");
                        IndexWriter.Unlock(directory);
                        //logger.Debug("解锁索引库完成");
                    }
                }

                IndexWriter writer = new IndexWriter(directory, new PanGuAnalyzer(), !isUpdate, IndexWriter.MaxFieldLength.UNLIMITED);

                //ProcessJobs(writer);
                Document document = new Document();
                string title = "title";
                string body = "body";
                string id = "1";
                //只有对需要全文检索的字段才ANALYZED
                document.Add(new Field("number", id, Field.Store.YES, Field.Index.NOT_ANALYZED));
                document.Add(new Field("title", title, Field.Store.YES, Field.Index.NOT_ANALYZED));
                document.Add(new Field("body", body, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS));
                writer.AddDocument(document);

                writer.Dispose();
                directory.Dispose();//不要忘了Close，否则索引结果搜不到
            }
        }

        private void ProcessJobs(IndexWriter writer)
        {
            //foreach (var job in jobs.ToArray())
            //{
            //    //todo:异常处理
            //    jobs.Remove(job);// 消费掉
            //    //因为是自己的网站，所以直接读取数据库，不用webclient了
            //    //为避免重复索引，所以先删除number=i的记录，再重新添加
            //    writer.DeleteDocuments(new Term("number", job.Id.ToString()));

            //    //如果“添加文章”任务再添加，
            //    if (job.JobType == JobType.Add)
            //    {
            //        RP_ArticleBLL artBll = new RP_ArticleBLL();
            //        if (artBll == null)//有可能刚添加就被删除了
            //        {
            //            continue;
            //        }
            //        var art = artBll.GetById(job.Id);
            //        string title = art.Title;
            //        string body = art.Msg;//去掉标签                

            //        Document document = new Document();
            //        //只有对需要全文检索的字段才ANALYZED
            //        document.Add(new Field("number", job.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            //        document.Add(new Field("title", title, Field.Store.YES, Field.Index.NOT_ANALYZED));
            //        document.Add(new Field("body", body, Field.Store.YES, Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS));
            //        writer.AddDocument(document);
            //        logger.Debug("索引" + job.Id + "完毕");
            //    }


            //}
        }

        public static IndexManager GetInstance()
        {
            //Queue<string> q;
            //q.ad
            return instance;
        }

        //private Queue<
        private List<IndexJob> jobs = new List<IndexJob>();

        public void AddArticle(int artId)
        {
            IndexJob job = new IndexJob();
            job.Id = artId;
            job.JobType = JobType.Add;
            //logger.Debug(artId + "加入任务列表");
            jobs.Add(job);//把任务加入商品库
        }

        public void RemoveArticle(int artId)
        {
            IndexJob job = new IndexJob();
            job.JobType = JobType.Remove;
            job.Id = artId;
            //logger.Debug(artId + "加入删除任务列表");
            jobs.Add(job);//把任务加入商品库
        }
    }

    class IndexJob
    {
        public int Id { get; set; }
        public JobType JobType { get; set; }
    }

    enum JobType { Add, Remove }

}
