using System.IO;
using System.Text;

namespace xCarpaccio.client
{
    using Nancy;
    using System;
    using Nancy.ModelBinding;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => "VIVE LE COCHON !";

            Post["/order"] = _ =>
            {
                using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    Console.WriteLine("Order received: {0}", reader.ReadToEnd());
                }

                var order = this.Bind<Order>();
                Bill bill = null;
                
                
                // Si on a une commande de l'allemagne
                if (order != null && order.Country == "DE")
                {


                    // Calcul sous-total (sans TVA ni réduction)
                    for (int i = 0; i < order.Prices.Length; i++)
                    {
                        sousTotal += (order.Prices[i]*order.Quantities[i]);
                    }

                    // Calcul avec TVA
                    sousTotalTVA = sousTotal*(decimal) 1.20;

                    // Calcul avec réduction
                    if (sousTotalTVA >= 1000)
                    {
                        total = sousTotalTVA*(decimal) 0.97;
                    }

                    // Else return a HTTP 404 error
                    else
                    {
                        return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
                    }

                
                    bill = total;
                }

                // Si pas de commande ou commande non-allemande
                // Else return a HTTP 404 error
                else
                {
                    return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
                    
                }
                
                // If you manage to get the result, return a Bill object (JSON serialization is done automagically)
                if (bill != null)
                {
                    return bill;
                }

                // Else return a HTTP 404 error
                else
                {
                    return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
                }
                
            };

            Post["/feedback"] = _ =>
            {
                var feedback = this.Bind<Feedback>();
                Console.Write("Type: {0}: ", feedback.Type);
                Console.WriteLine(feedback.Content);
                return Negotiate.WithStatusCode(HttpStatusCode.OK);
            };
        }
    }
}