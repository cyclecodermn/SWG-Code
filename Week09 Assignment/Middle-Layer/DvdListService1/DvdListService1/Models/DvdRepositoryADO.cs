using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DvdListService1.Models
{
    public class DvdRepositoryADO : IDvdRepository
    {
        SqlConnection conn = new SqlConnection();

        public DvdRepositoryADO()
        {
            conn.ConnectionString = "Server=localhost;Database=DvdLibrary;user id=DvdLibraryApp; password=testing123;";
        }

        public void Create(DVD newDVD)
        {
            throw new NotImplementedException();
        }

        public void Delete(int DvdId)
        {
            throw new NotImplementedException();
        }

        public DVD Get(int DvdId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DVD> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DVD> GetByDirector(string term)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DVD> GetByRating(string term)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DVD> GetByTitle(string term)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DVD> GetByYear(string term)
        {
            throw new NotImplementedException();
        }

        public void Update(DVD updatedDVD)
        {
            throw new NotImplementedException();
        }
    }
}