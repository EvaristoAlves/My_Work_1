using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            

            IOrganizationService service = ConnectionFactory.GetService();

           
            Entity conta = new Entity("account");
            Console.WriteLine("Por favor, informe o nome da conta!");
            conta["name"] = Console.ReadLine();

            Console.WriteLine("Por favor, informe o site da conta!");
            conta["websiteurl"] = Console.ReadLine(); 

            Console.WriteLine("Por favor, informe o total de oportunidade!");
            var valor= Convert.ToDecimal(Console.ReadLine());
            conta["eac_totaldeoportunidades"] = new Money(valor);

            Console.WriteLine("Por favor, informe o tamanho da empresa!");
            var tamanho= Console.ReadLine();
            if (tamanho=="pequena")
            {
                conta["eac_portedaempresa"] = new OptionSetValue(783910000);
            }else if (tamanho == "média") 
            {
                conta["eac_portedaempresa"] = new OptionSetValue(783910001);
            }
            else
            {
                conta["eac_portedaempresa"] = new OptionSetValue(783910002);
            }
            
            conta["eac_totaldeproduto"] = new Decimal(10.1);
            Guid accountId = service.Create(conta);

            Console.WriteLine("Você deseja criar um contato para esta conta? (S/N)");
            var resposta = Console.ReadLine();

            switch (resposta)
            {
                case"S":
                    Entity contato = new Entity("contact");
                    Console.WriteLine("Digite o primeiro nome do contato!");
                    contato["firstname"] = Console.ReadLine();
                    Console.WriteLine("Digite o primeiro último nome do contato!");
                    contato["larstname"] = Console.ReadLine();
                    Console.WriteLine("Digite o e-mail do contato!");
                    contato["emailaddress1"] = Console.ReadLine();
                    Console.WriteLine("Digite o celular do contato!");
                    contato["mobilephone"] = Console.ReadLine();
                    contato["parentcustomerid"] = new EntityReference("account", accountId);
                    service.Create(contato);
                    break;
                case "N":
                    Console.WriteLine("Fim do cadastro!");
                    break;
                    default:
                    Console.WriteLine("Digite S para sim ou N para não");
                    break;
            }
            
            
           
            
            

        }
    }
}
