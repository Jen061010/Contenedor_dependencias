using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contenedor_dependencias
{
    class Program
    {
        static void Main(string[] args)
        {
            //var service=new Service(new Repository);
            /*IService service= new Service(new Repository());
            service.Add();*/
            var serviceType = Type.GetType("Contenedor_dependencias.Service");
            var repositoryType = Type.GetType("Contenedor_dependencias.Repository");
            var IRepository=repositoryType.GetConstructors()[0].Invoke(new object[]{});
            var IService=serviceType.GetConstructors()[0].Invoke(new object[] { IRepository });// Estoy almacenando la clase repository
            serviceType.GetMethod("Add").Invoke(IService,new object[]{});
            Console.ReadLine();
        }
    }
}
