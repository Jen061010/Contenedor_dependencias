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

            //Ahora vamos a hacer lo mismo que anteriormente pero por reflexion
            var serviceType = Type.GetType("Contenedor_dependencias.Service");
            var repositoryType = Type.GetType("Contenedor_dependencias.Repository");
            //Sólo tenemos un constructor pero no se usa getConstructor porque se tendrían que indicar los tipos
            var IRepository=repositoryType.GetConstructors()[0].Invoke(new object[]{});
            var IService=serviceType.GetConstructors()[0].Invoke(new object[] { IRepository });// Estoy almacenando la clase repository
            serviceType.GetMethod("Add").Invoke(IService,new object[]{});
            Console.ReadLine();
        }
    }
}
