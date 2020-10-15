using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Entity;

namespace Agenda.BLL
{
    public class MemoryExampleBusiness : IExampleBusiness, IDisposable
    {
        private List<Usuario> lstExample;
        public void Dispose()
        {
        }

        public MemoryExampleBusiness(List<Usuario> lstExample)
        {            
            this.lstExample = lstExample;
        }

        //public Usuario GetExampleByID(Usuario example)
        //{
        //    //return this.lstExample.Single(p => p.id.Equals(example.id));
        //}

        //public List<Usuario> GetListExampleByFilter(ExampleFilter exampleFilter)
        //{
        //    //if (!string.IsNullOrEmpty(exampleFilter.value))
        //    //{
        //    //    return this.lstExample.FindAll(p => p.value.Contains(exampleFilter.value)).OrderBy(p => p.id).ToList();                
        //    //}
        //    //else 
        //    //{
        //    //    return this.lstExample.OrderBy(p => p.id).ToList();
        //    //}
        //}

        //public Usuario Insert(Usuario example)
        //{            
        //    //int max = this.lstExample.OrderByDescending(x => x.id).First().id.Value;
        //    //example.id = (max + 1);
        //    //this.lstExample.Add(example);

        //    //return example;
        //}

        public void Update(Usuario example)
        {
            this.lstExample.Remove(example);
            this.lstExample.Add(example);
        }

        public void Delete(Usuario example)
        {
        //    Usuario exampleDelete = this.lstExample.Find(p => p.id.Equals(example.id));
        //    if (example != null)
        //    { 
        //        this.lstExample.Remove(exampleDelete);
        //    }
        }

    }
}
