using DAL.Entities;
using System.Collections.Generic;

namespace DAL.EntityRepositories
{
    internal class FileRepository
    {
        private List<File> files;

        public FileRepository()
        {
            files = new List<File>();
        }

        public FileRepository(File file)
        {
            files = new List<File>();
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
