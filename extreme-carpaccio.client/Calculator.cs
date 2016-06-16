using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using Nancy.ModelBinding;

namespace xCarpaccio.client
{
    public class Calculator
    {
        public Bill CalculBill(Bill bill, Order order)
        {
            decimal sousTotal = 0;
                decimal sousTotalTVA = 0;
                decimal total = 0;
                bill = null;
                //TODO: do something with order and return a bill if possible
                
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

                    // Si pas de reduc, return a HTTP 404 error
                    else
                    {
                        return null;
                    }

                
                    bill = new Bill(total);
                }

                // Si pas de commande ou commande non-allemande
                // Else return a HTTP 404 error
                else
                {
                    return null;
                    
                }
                
                // If you manage to get the result, return a Bill object (JSON serialization is done automagically)
                if (bill != null)
                {
                    return bill;
                }

                // Else return a HTTP 404 error
                else
                {
                    return null;
                }
                
            };
        }
        
    }
}
