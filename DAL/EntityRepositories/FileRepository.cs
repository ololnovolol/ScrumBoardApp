using DAL.Entities;
using System.Collections.Generic;

namespace DAL.EntityRepositories
{
    internal class FileRepository
    {
        private List<Attachment> files;

        public FileRepository()
        {
            files = new List<Attachment>();
        }

        public FileRepository(Attachment file)
        {
            files = new List<Attachment>();
            files.Add(file);
        }

        public void Add()
        {

        }

        public void Change()
        {

        }

        public void Delete()
        {

        }

        public void Get()
        {

        }

        public void GetAll()
        {

        }
    }
}
