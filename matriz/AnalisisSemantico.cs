using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matriz
{
    internal class AnalisisSemantico
    {
        public string Asignacion(int TipoVariable, Token Valor, int TipoValor)
        {
            if (Valor.No_token == 103) //es variable
            {
                Valor.No_token = TipoValor;
            }
            switch (TipoVariable)
            {
                //entero
                case 140:
                    {
                        if (Valor.No_token != 101 && Valor.No_token != 140)
                        {
                            return "Error de semantica. Se esperaba valor tipo Entero." + ImpresionRenglonFix(Valor);
                        }
                        break;
                    }

                //real
                case 141: 
                    { 
                        if (Valor.No_token != 102 && Valor.No_token != 101 && Valor.No_token != 141)
                        {
                            return "Error de semantica. Se esperaba valor tipo Real." + ImpresionRenglonFix(Valor);
                        }
                        break;
                    }
                //booleano
                case 142: { break; }
                //cadena
                case 143: 
                    {
                        if (Valor.No_token != 159 && Valor.No_token != 143)
                        {
                            return "Error de semantica. Se esperaba valor tipo Cadena." + ImpresionRenglonFix(Valor);
                        }
                        break;
                    }
            }

            return "";
        }

        public string Condiciones(Token Condicion1, Token Condicion2, ArrayList Variables, ArrayList TipoVariables)
        {
            if (Condicion1.No_token == 103)
            {
                Condicion1.No_token = (int)TipoVariables[IndexOfVariable(Condicion1.Simbolo, Variables)];
            }
            if (Condicion2.No_token == 103)
            {
                Condicion2.No_token = (int)TipoVariables[IndexOfVariable(Condicion2.Simbolo, Variables)];
            }
            

            switch (Condicion1.No_token)
            {
                //entero
                case 140:
                case 101:
                    {
                        if (Condicion2.No_token != 101 && Condicion2.No_token != 140)
                        {
                            return "Error de semantica. Se esperaba comparacion con tipo Entero." + ImpresionRenglonFix(Condicion2);
                        }
                        break;
                    }

                //real
                case 141:
                case 102:
                    {
                        if (Condicion2.No_token != 102 && Condicion2.No_token != 141)
                        {
                            return "Error de semantica. Se esperaba comparacion con tipo Real." + ImpresionRenglonFix(Condicion2);
                        }
                        break;
                    }
                //booleano
                case 142: { break; }
                //cadena
                case 143:
                case 159:
                    {
                        if (Condicion2.No_token != 159 && Condicion2.No_token != 143)
                        {
                            return "Error de semantica. Se esperaba comparacion con tipo Cadena." + ImpresionRenglonFix(Condicion2);
                        }
                        break;
                    }
            }

            return "";
        }
        public int IndexOfVariable(string Simbolo, ArrayList variables)
        {
            int contador = 0;
            foreach (Object variable in variables)
            {
                if (((string)variable).Equals(Simbolo))
                {
                    return contador;
                }
                contador++;
                // loop body
            }
            return 0;
        }
        public String ImpresionRenglonFix(Token TokenError)
        {
            String Renglon = "[ID:" + TokenError.ID + " Token:" + TokenError.No_token + " en renglon: " + TokenError.Renglon + "]";
            return Renglon;
        }



    }
}
