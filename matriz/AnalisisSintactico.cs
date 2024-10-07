using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matriz
{
    internal class AnalisisSintactico
    {
        //análisis sintáctico 
        int cont = 0;
        public ArrayList tokens = new ArrayList();
        public String Mensaje = "";
        public ArrayList variables = new ArrayList();//almacena variables declaradas
        public ArrayList TipoVariable = new ArrayList();//almacena variables declaradas

        public ArrayList Funciones = new ArrayList();//almacena variables declaradas
        public ArrayList TipoFuncion = new ArrayList();//almacena variables declaradas
        public String estructura( ArrayList TokenList)
        {

            tokens = TokenList;
            cont = 0;
            int last = tokens.Count - 1;//último token registrado
            Console.Clear();

            // Console.WriteLine(((Token)(tokens[cont])).No_token);
            if (((Token)tokens[cont]).No_token != 157) { return ("Error de sintaxis. Se esperaba la palabra programa. " + ImpresionRenglonFix() );  }
            if (cont < last) { cont++; }
            if (((Token)tokens[cont]).No_token != 103) { return ("Error de sintaxis.Se esperaba identificador de programa. " + ImpresionRenglonFix() ); }
            if (cont < last) { cont++; }
            if (((Token)tokens[cont]).No_token != 130) { return ("Error de sintaxis. Se esperaba punto y coma. " + ImpresionRenglonFix() ); }
            if (cont < last) { cont++; }

            do
            {
                if (((Token)tokens[cont]).No_token == 150)
                {
                    Mensaje = funcion();
                    if (!Mensaje.Equals("")) { return Mensaje; }
                } //si se identifica el token de funcion, se ignora la declaración de variables.
                else if (((Token)tokens[cont]).No_token == 140 || ((Token)(tokens[cont])).No_token == 141
                    || ((Token)(tokens[cont])).No_token == 142 || ((Token)(tokens[cont])).No_token == 143)
                {
                    int TipoDato = ((Token)(tokens[cont])).No_token;
                    if (cont < last) { cont++; }
                    Mensaje = declaracion(TipoDato);
                    if (!Mensaje.Equals("")) { return Mensaje; }
                }
                else if(((Token)tokens[cont]).No_token == 151)
                {
                    Mensaje = bloque();
                    if (!Mensaje.Equals("")) { return Mensaje; }
                    if (((Token)(tokens[cont])).No_token != 152)
                    {
                            return ("Error de sintaxis. Se esperaba un 'fin'. " + ImpresionRenglonFix());
                        
                    }
                    if (cont != last) { return ("Error de sintaxis. Instruccion no valida." + ImpresionRenglonFix()); }
                    break;
                }
                else
                {
                        return ("Error de sintaxis. Se esperaba 'inicio' de bloque. " + ImpresionRenglonFix());
                    
                }
                if (!(cont < last)) {
                    if (((Token)(tokens[cont])).No_token != 152)
                    {
                        return ("Error de sintaxis. Se esperaba un 'fin'. " + ImpresionRenglonFix());

                    }
                    break; }
            } while (true);

            ///////////////////////////////////////////////////////////////////////

            return Mensaje;
        }
        public String instrucciones(int token)
        {
            int last = tokens.Count - 1;//último token registrado
            switch (token)
            {
                case 103:
                    {
                        if (Funciones.Contains(((Token)(tokens[cont])).Simbolo) == true) { return LlamadaFuncion(); }
                        else { return asignacion(); }
                    }
                case 140: case 141: case 142: case 143: { if (cont < last) { cont++; } return declaracion(token); }
                case 144: { if (cont < last) { cont++; } return cond_if(); }
                case 155: { if (cont < last) { cont++; } return ciclo_desde();  } //no terminado
                case 149: { if (cont < last) { cont++; } return ciclo_while();  }
                case 148: { if (cont < last) { cont++; } return ciclo_DOwhile();  }
                case 154: { if (cont < last) { cont++; } return escribir();  }
                case 153: { if (cont < last) { cont++; } return leer(); }
                default: { return ("Instruccion no valida, " + ImpresionRenglonFix());  }
            }
        }

        public String ImpresionRenglonFix()
        {
            String Renglon = "[ID:" + ((Token)tokens[cont]).ID + ". Token:" + ((Token)tokens[cont]).No_token 
                + ". en renglon: " + ((Token)tokens[cont]).Renglon+"]";
            return Renglon;
        }
        public String declaracion(int TokenTipoDato)
        {
            int last = tokens.Count - 1;
            bool ban = false;
            Token valor;
            AnalisisSemantico AuxSemantica = new AnalisisSemantico();
        a:
            if (((Token)(tokens[cont])).No_token != 103) { return ("Error de sintaxis. Se esperaba identificador. " + ImpresionRenglonFix()); }
            if (variables.Contains(((Token)(tokens[cont])).Simbolo) == true) { return ("Error de semantica. La variable ha sido declarada anteriormente. " + ImpresionRenglonFix()); }
            variables.Add(((Token)(tokens[cont])).Simbolo);
            TipoVariable.Add(TokenTipoDato);
            if (cont < last) { cont++; }
            if (((Token)(tokens[cont])).No_token != 112)
            {
                if (((Token)(tokens[cont])).No_token == 162)
                {
                    if (cont < last) { cont++; }
                    goto a;
                }
                if (((Token)(tokens[cont])).No_token != 130)
                {
                    return ("Error de sintaxis. Se esperaba punto y coma o simbolo de asignación. " + ImpresionRenglonFix());
                }
                if (cont < last) { cont++; }
            }
            else
            {
                if (cont < last) { cont++; }
                do
                {
                    ban = true;


                    if (((Token)(tokens[cont])).No_token != 159 && ((Token)(tokens[cont])).No_token != 101 && ((Token)(tokens[cont])).No_token != 102 && ((Token)(tokens[cont])).No_token != 103)
                    {
                        return ("Error de sintaxis. Se esperaba asignar un valor. " + ImpresionRenglonFix());
                    }
                    if (((Token)(tokens[cont])).No_token == 103)
                    {
                        if (variables.Contains(((Token)(tokens[cont])).Simbolo) != true) { return ("Error de semantica. La variable no ha sido declarada anteriormente. " + ImpresionRenglonFix()); }
                    }
                    valor = (Token)tokens[cont];
                    int TipoValor = 0;
                    if (valor.No_token == 103)
                    {
                        TipoValor = (int)TipoVariable[IndexOfVariable(valor.Simbolo)];
                    }
                    Mensaje = AuxSemantica.Asignacion(TokenTipoDato, valor, TipoValor);
                    if (!Mensaje.Equals("")) { return Mensaje; }
                    if (cont < last) { cont++; }

                    if (((Token)(tokens[cont])).No_token == 162)
                    {
                        if (cont < last) { cont++; }
                        goto a;
                    }

                    if (((Token)(tokens[cont])).No_token != 104 && ((Token)(tokens[cont])).No_token != 105 && ((Token)(tokens[cont])).No_token != 106 && ((Token)(tokens[cont])).No_token != 107)
                    {
                        if (((Token)(tokens[cont])).No_token != 130)
                        {
                            return ("Error de sintaxis. Se esperaba punto y coma. " + ImpresionRenglonFix());
                        }
                        else
                        {
                            ban = false;
                        }
                    }
                    if (cont < last) { cont++; }

                    else { ban = false; }

                } while (ban);
            }
            return Mensaje;
        }
        public String bloque()
        {
            int last = tokens.Count - 1;//último token registrado

            if (cont < last) { cont++; }
            while (((Token)(tokens[cont])).No_token != 156 && ((Token)(tokens[cont])).No_token != 152)
            {
                Mensaje = instrucciones(((Token)(tokens[cont])).No_token);
                if (!Mensaje.Equals("")) { return Mensaje; }
                //if (!(cont <= last)) { break; }
            }
            if (!(cont < last))
            {
                if (((Token)(tokens[cont])).No_token != 152)
                {
                    return ("Error de sintaxis. Se esperaba un 'fin'. " + ImpresionRenglonFix());
                }
            }

            



            //if (((Token)(tokens[cont])).No_token != 128) { return ("Error de sintaxis. Se esperaba '}' "); }

            return Mensaje;

        }
        public String funcion()
        {
            int last = tokens.Count - 1;//último token registrado

            if (cont < last) { cont++; }
            if (((Token)tokens[cont]).No_token != 140 && ((Token)(tokens[cont])).No_token != 141
                    && ((Token)(tokens[cont])).No_token != 142 && ((Token)(tokens[cont])).No_token != 143)
            {
                return ("Error de sintaxis. Se esperaba tipo de dato para funcion. " + ImpresionRenglonFix());
            }

            int tipovariable = ((Token)tokens[cont]).No_token;

            if (cont < last) { cont++; }
            if (((Token)(tokens[cont])).No_token != 103) { return ("Error de sintaxis. Se esperaba identificador en la funcion. " + ImpresionRenglonFix() ); }

            if (Funciones.Contains(((Token)(tokens[cont])).Simbolo) == true) { return ("Error de semantica. La variable ha sido declarada anteriormente. " + ImpresionRenglonFix()); }
            Funciones.Add(((Token)(tokens[cont])).Simbolo);
            TipoFuncion.Add(tipovariable);

            if (cont < last) { cont++; }
            if (((Token)(tokens[cont])).No_token != 160) { return ("Error de sintaxis. Se esperaba '(' en la funcion. " + ImpresionRenglonFix() ); }

            /////////PARAMETROS
            if (cont < last) { cont++; }
            if (((Token)(tokens[cont])).No_token != 161)
            {
                while (true)
                {
                    if (((Token)(tokens[cont])).No_token != 140 && ((Token)(tokens[cont])).No_token != 141
                        && ((Token)(tokens[cont])).No_token != 142 && ((Token)(tokens[cont])).No_token != 143)
                    {
                        return ("Error de sintaxis. Se esperaba tipo de dato en parametros. " + ImpresionRenglonFix() ); 
                    }
                    if (cont < last) { cont++; }
                    if (((Token)(tokens[cont])).No_token != 103)
                    {
                        return ("Error de sintaxis. Se esperaba identificador en parametros. " + ImpresionRenglonFix() );
                    }
                    if (cont < last) { cont++; }
                    if (((Token)(tokens[cont])).No_token != 162)
                    {
                        if (((Token)(tokens[cont])).No_token != 161)
                        {
                            return ("Error de sintaxis. Se esperaba ')'" + ImpresionRenglonFix() );
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (cont < last) { cont++; }

                }
            }

            if (cont < last) { cont++; }
            if (((Token)(tokens[cont])).No_token != 151)
            {
                return ("Error de sintaxis. Se esperaba 'inicio' de funcion. " + ImpresionRenglonFix() );                 
            }

            if (cont < last) { cont++; }
            while (((Token)(tokens[cont])).No_token != 156 && ((Token)(tokens[cont])).No_token != 152)
            {
                Mensaje = instrucciones(((Token)(tokens[cont])).No_token);
                if (!Mensaje.Equals("")) { return Mensaje; }
                //if (!(cont <= last)) { break; }
            }
            //asdasd
            if (((Token)(tokens[cont])).No_token == 156)
            {
                // returnar
                if (cont < last) { cont++; }
                bool ban = true;
                AnalisisSemantico AuxSemantica = new AnalisisSemantico();
                Token valor;
                do
                {
                    ban = true;


                    //if (expresion() != true) { return ("Error de sintaxis. La expresión asignada es inválida"); return; }

                    if (((Token)(tokens[cont])).No_token != 159 && ((Token)(tokens[cont])).No_token != 101 && ((Token)(tokens[cont])).No_token != 102 && ((Token)(tokens[cont])).No_token != 103)
                    {
                        return ("Error de sintaxis. Se esperaba asignar un valor. " + ImpresionRenglonFix());
                    }
                    if (((Token)(tokens[cont])).No_token == 103)
                    {
                        if (variables.Contains(((Token)(tokens[cont])).Simbolo) != true) { return ("Error de semantica. La variable no ha sido declarada anteriormente. " + ImpresionRenglonFix()); }
                    }
                    valor = (Token)tokens[cont];
                    int TipoValor = 0;
                    if (valor.No_token == 103)
                    {
                        TipoValor = (int)TipoVariable[IndexOfVariable(valor.Simbolo)];
                    }
                    Mensaje = AuxSemantica.Asignacion(tipovariable, valor, TipoValor);
                    if (!Mensaje.Equals("")) { return Mensaje; }
                    if (cont < last) { cont++; }


                    if (((Token)(tokens[cont])).No_token != 104 && ((Token)(tokens[cont])).No_token != 105 && ((Token)(tokens[cont])).No_token != 106 && ((Token)(tokens[cont])).No_token != 107)
                    {
                        if (((Token)(tokens[cont])).No_token != 130)
                        {
                            return ("Error de sintaxis. Se esperaba punto y coma. " + ImpresionRenglonFix());
                        }
                        else
                        {
                            ban = false;
                        }
                    }
                    if (cont < last) { cont++; }

                    else { ban = false; }

                } while (ban);

            }
            else
            {
                return ("Error de sintaxis. Se esperaba regresar algun valor en la funcion. " + ImpresionRenglonFix());
            }

            if (cont < last) { cont++; }
            else
            {
                if (((Token)(tokens[cont])).No_token != 152)
                {
                    return ("Error de sintaxis. Se esperaba un 'fin'. " + ImpresionRenglonFix() );
                }

            }

            //if (((Token)(tokens[cont])).No_token != 128) { return ("Error de sintaxis. Se esperaba '}' "); }

            return Mensaje;
        }

       public int IndexOfVariable(string Simbolo)
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
        public int IndexOfFuncion(string Simbolo)
        {
            int contador = 0;
            foreach (Object funcion in Funciones)
            {
                if (((string)funcion).Equals(Simbolo))
                {
                    return contador;
                }
                contador++;
                // loop body
            }
            return 0;
        }
        public String asignacion()
        {
            int last = tokens.Count - 1;
            AnalisisSemantico AuxSemantica = new AnalisisSemantico();
            int variable;
            Token valor;
            //preguntamos si la variable existe 
            if (variables.Contains(((Token)(tokens[cont])).Simbolo) != true) {  return ("Error de semantica. La variable no ha sido declarada anteriormente. " + ImpresionRenglonFix() ); }
            variable = (int)TipoVariable[IndexOfVariable(((Token)(tokens[cont])).Simbolo)];
            if (cont < last) { cont++; }
            if (((Token)(tokens[cont])).No_token != 112 && ((Token)(tokens[cont])).No_token != 113 && ((Token)(tokens[cont])).No_token != 114
                && ((Token)(tokens[cont])).No_token != 115 && ((Token)(tokens[cont])).No_token != 116)
            {
                return ("Error de sintaxis. Se esperaba asignacion. " + ImpresionRenglonFix() );
            }
            if (cont < last) { cont++; }
            bool ban = true;
            do
            {
                ban = true;


                if (((Token)(tokens[cont])).No_token != 159 && ((Token)(tokens[cont])).No_token != 101 && ((Token)(tokens[cont])).No_token != 102 && ((Token)(tokens[cont])).No_token != 103)
                {
                    return ("Error de sintaxis. Se esperaba asignar un valor. " + ImpresionRenglonFix());
                }
                if (((Token)(tokens[cont])).No_token == 103)
                {
                    if (variables.Contains(((Token)(tokens[cont])).Simbolo) != true) { return ("Error de semantica. La variable no ha sido declarada anteriormente. " + ImpresionRenglonFix()); }
                }
                valor = (Token)tokens[cont];
                int TipoValor = 0;
                if (valor.No_token == 103)
                {
                   TipoValor = (int)TipoVariable[IndexOfVariable(valor.Simbolo)];
                }
                Mensaje = AuxSemantica.Asignacion(variable, valor, TipoValor);
                if (!Mensaje.Equals("")) { return Mensaje; }
                if (cont < last) { cont++; }


                if (((Token)(tokens[cont])).No_token != 104 && ((Token)(tokens[cont])).No_token != 105 && ((Token)(tokens[cont])).No_token != 106 && ((Token)(tokens[cont])).No_token != 107)
                {
                    if (((Token)(tokens[cont])).No_token != 130)
                    {
                        return ("Error de sintaxis. Se esperaba punto y coma. " + ImpresionRenglonFix() );
                    }
                    else
                    {
                        ban = false;
                    }
                }
                if (cont < last) { cont++; }

                else { ban = false; }

            } while (ban);
            return Mensaje;

        }

        public String ciclo_desde()
        {
            int last = tokens.Count - 1;//último token registrado

            //asignacion
            if (variables.Contains(((Token)(tokens[cont])).Simbolo) != true) { return ("Error de semantica. La variable no ha sido declarada anteriormente. " + ImpresionRenglonFix()); }
            if (cont < last) { cont++; }
            if (((Token)(tokens[cont])).No_token != 112)
            {
                return ("Error de sintaxis. Se esperaba asignacion. " + ImpresionRenglonFix());
            }
            if (cont < last) { cont++; }

            

            bool ban = true;
            do
            {
                ban = true;


                //if (expresion() != true) { return ("Error de sintaxis. La expresión asignada es inválida"); return; }

                if ( ((Token)(tokens[cont])).No_token != 101)
                {
                    return ("Error de sintaxis. Se esperaba asignar un valor tipo entero. " + ImpresionRenglonFix());
                }
                if (cont < last) { cont++; }
                if (((Token)(tokens[cont])).No_token != 104 && ((Token)(tokens[cont])).No_token != 105 && ((Token)(tokens[cont])).No_token != 106 && ((Token)(tokens[cont])).No_token != 107)
                {
                    if (((Token)(tokens[cont])).No_token != 147)
                    {
                        return ("Error de sintaxis. Se esperaba 'hasta'. " + ImpresionRenglonFix());
                    }
                    else
                    {
                        ban = false;
                    }
                }
                if (cont < last) { cont++; }

                else { ban = false; }

            } while (ban);

            if (((Token)(tokens[cont])).No_token != 101)
            {
                return ("Error de sintaxis. Se esperaba numero entero. " + ImpresionRenglonFix());
            }
            if (cont < last) { cont++; }
            //asignacion

           
            if (((Token)(tokens[cont])).No_token != 151) { return ("Error de sintaxis. Se esperaba un 'inicio'. " + ImpresionRenglonFix()); }
            if (cont < last) { cont++; }
            while (((Token)(tokens[cont])).No_token != 152 && cont < last)
            {
                Mensaje = instrucciones(((Token)(tokens[cont])).No_token);
                if (!Mensaje.Equals("")) { return Mensaje; }
                //if (!(cont <= last)) { break; }
            }
            if (cont < last) { cont++; }
            else { return ("Error de sintaxis. Se esperaba un 'fin'. " + ImpresionRenglonFix()); }
            return Mensaje;
        }

        public String ciclo_while()
        {
            int last = tokens.Count - 1;//último token registrado

            if (((Token)(tokens[cont])).No_token != 160) { return ("Error de sintaxis. Se esperaba '(' " + ImpresionRenglonFix()); }
            if (cont < last) { cont++; }

            bool ban = true;
            Token condicion1, condicion2;
            AnalisisSemantico AuxSemantica = new AnalisisSemantico();
            /////
            ///
            Mensaje = Expresion();
            if (!Mensaje.Equals("")) { return Mensaje; }


            if (((Token)(tokens[cont])).No_token != 161)
            {
                return ("Error de sintaxis. Se esperaba ')'. " + ImpresionRenglonFix());
            }
            if (cont < last) { cont++; }

            if (((Token)(tokens[cont])).No_token != 151) { if (cont < last) { cont++; } return ("Error de sintaxis. Se esperaba un 'inicio'. " + ImpresionRenglonFix() ); }
            if (cont < last) { cont++; }
            while (((Token)(tokens[cont])).No_token != 152 && cont < last)
            {
                Mensaje = instrucciones(((Token)(tokens[cont])).No_token);
                if (!Mensaje.Equals("")) { return Mensaje; }
                //if (!(cont <= last)) { break; }
            }
            if (cont < last) { cont++; }
            else { return ("Error de sintaxis. Se esperaba un 'fin'. " + ImpresionRenglonFix() ); }
            return Mensaje;
        }

        public String ciclo_DOwhile()
        {
            int last = tokens.Count - 1;//último token registrado


            if (((Token)(tokens[cont])).No_token != 151) { if (cont < last) { cont++; } return ("Error de sintaxis. Se esperaba un 'inicio'. " + ImpresionRenglonFix()); }
            if (cont < last) { cont++; }
            while (((Token)(tokens[cont])).No_token != 152 && cont < last)
            {
                Mensaje = instrucciones(((Token)(tokens[cont])).No_token);
                if (!Mensaje.Equals("")) { return Mensaje; }
                //if (!(cont <= last)) { break; }
            }
            if (cont < last) { cont++; }
            else { return ("Error de sintaxis. Se esperaba un 'fin'. " + ImpresionRenglonFix()); }

            if (((Token)(tokens[cont])).No_token != 149) { return ("Error de sintaxis. Se esperaba 'Mientras' " + ImpresionRenglonFix()); }
            if (cont < last) { cont++; }

            if (((Token)(tokens[cont])).No_token != 160) { return ("Error de sintaxis. Se esperaba '(' " + ImpresionRenglonFix()); }
            if (cont < last) { cont++; }

            bool ban = true;
            Token condicion1, condicion2;
            AnalisisSemantico AuxSemantica = new AnalisisSemantico();
            /////
            ///
            Mensaje = Expresion();
            if (!Mensaje.Equals("")) { return Mensaje; }


            if (((Token)(tokens[cont])).No_token != 161)
            {
                return ("Error de sintaxis. Se esperaba ')'. " + ImpresionRenglonFix());
            }
            if (cont < last) { cont++; }
            if (((Token)(tokens[cont])).No_token != 130) { return ("Error de sintaxis. Se esperaba ';'. " + ImpresionRenglonFix()); }
            if (cont < last) { cont++; }

            return Mensaje;
        }
        public String cond_if_OLD()
        {
            int last = tokens.Count - 1;//último token registrado

            if (((Token)(tokens[cont])).No_token != 160) { return ("Error de sintaxis. Se esperaba '(' " + ImpresionRenglonFix()); }
            if (cont < last) { cont++; }

            bool ban = true;
            Token condicion1, condicion2;
            AnalisisSemantico AuxSemantica = new AnalisisSemantico();
            do
            {
                ban = true;
                //if (expresion() != true) { return ("Error de sintaxis. La expresión asignada es inválida"); return; }
                if (((Token)(tokens[cont])).No_token == 126)
                {
                    if (cont < last) { cont++; }
                }
                if (((Token)(tokens[cont])).No_token != 159 && ((Token)(tokens[cont])).No_token != 101 && ((Token)(tokens[cont])).No_token != 102 && ((Token)(tokens[cont])).No_token != 103)
                {
                    return ("Error de sintaxis. Se esperaba un valor. " + ImpresionRenglonFix() );
                }
                condicion1 = (Token)tokens[cont];
                if (cont < last) { cont++; }
                if (((Token)(tokens[cont])).No_token != 118 && ((Token)(tokens[cont])).No_token != 119 && ((Token)(tokens[cont])).No_token != 120 && ((Token)(tokens[cont])).No_token != 121
                    && ((Token)(tokens[cont])).No_token != 122 && ((Token)(tokens[cont])).No_token != 123)
                {

                    return ("Error de sintaxis. Se esperaba operador relacional. " + ImpresionRenglonFix() );
                }
                if (cont < last) { cont++; }
                if (((Token)(tokens[cont])).No_token != 159 && ((Token)(tokens[cont])).No_token != 101 && ((Token)(tokens[cont])).No_token != 102 && ((Token)(tokens[cont])).No_token != 103)
                {
                    return ("Error de sintaxis. Se esperaba un valor." + ImpresionRenglonFix());
                }
                condicion2 = (Token)tokens[cont];
                Mensaje = AuxSemantica.Condiciones(condicion1, condicion2, variables, TipoVariable);
                if (!Mensaje.Equals("")) { return Mensaje; }
                if (cont < last) { cont++; }
                if (((Token)(tokens[cont])).No_token != 124 && ((Token)(tokens[cont])).No_token != 125)
                {
                    if (((Token)(tokens[cont])).No_token != 161)
                    {
                        return ("Error de sintaxis. Se esperaba ')'. " + ImpresionRenglonFix() );
                    }
                    else
                    {
                        ban = false;
                    }
                }

                if (cont < last) { cont++; }

                else { ban = false; }

            } while (ban);

            if (((Token)(tokens[cont])).No_token != 145) { if (cont < last) { cont++; } return ("Error de sintaxis. Se esperaba un 'entonces' " + ImpresionRenglonFix() ); }
            if (cont < last) { cont++; }

            if (((Token)(tokens[cont])).No_token != 151) { if (cont < last) { cont++; } return ("Error de sintaxis. Se esperaba un 'inicio' " + ImpresionRenglonFix() ); }
            if (cont < last) { cont++; }
            while (((Token)(tokens[cont])).No_token != 152 && cont < last)
            {
                Mensaje = instrucciones(((Token)(tokens[cont])).No_token);
                if (!Mensaje.Equals("")) { return Mensaje; }
                //if (!(cont <= last)) { break; }
            }
            if (cont < last) { cont++; }
            else { return ("Error de sintaxis. Se esperaba un 'fin' " + ImpresionRenglonFix() ); }
            //else
            if (((Token)(tokens[cont])).No_token == 146)
            {
                if (cont < last) { cont++; }
                if (((Token)(tokens[cont])).No_token != 151) { if (cont < last) { cont++; } return ("Error de sintaxis. Se esperaba un 'inicio'. " + ImpresionRenglonFix() ); }
                if (cont < last) { cont++; }
                while (((Token)(tokens[cont])).No_token != 152 && cont < last)
                {
                    Mensaje = instrucciones(((Token)(tokens[cont])).No_token);
                    if (!Mensaje.Equals("")) { return Mensaje; }
                    //if (!(cont <= last)) { break; }
                }
                if (cont < last) { cont++; }
                else { return ("Error de sintaxis. Se esperaba un 'fin'. " + ImpresionRenglonFix() ); }
            }
            return Mensaje;
        }
        public String cond_if()
        {
            int last = tokens.Count - 1;//último token registrado

            if (((Token)(tokens[cont])).No_token != 160) { return ("Error de sintaxis. Se esperaba '(' " + ImpresionRenglonFix()); }
            if (cont < last) { cont++; }

            bool ban = true;
            Token condicion1, condicion2;
            AnalisisSemantico AuxSemantica = new AnalisisSemantico();
            /////
            ///
            Mensaje = Expresion();
            if (!Mensaje.Equals("")) { return Mensaje; }


            if (((Token)(tokens[cont])).No_token != 161)
            {
                return ("Error de sintaxis. Se esperaba ')'. " + ImpresionRenglonFix());
            }
            if (cont < last) { cont++; }

            if (((Token)(tokens[cont])).No_token != 145) { return ("Error de sintaxis. Se esperaba un 'entonces' " + ImpresionRenglonFix()); }
            if (cont < last) { cont++; }

            if (((Token)(tokens[cont])).No_token != 151) { return ("Error de sintaxis. Se esperaba un 'inicio' " + ImpresionRenglonFix()); }
            if (cont < last) { cont++; }
            while (((Token)(tokens[cont])).No_token != 152 && cont < last)
            {
                Mensaje = instrucciones(((Token)(tokens[cont])).No_token);
                if (!Mensaje.Equals("")) { return Mensaje; }
                //if (!(cont <= last)) { break; }
            }
            if (cont < last) { cont++; }
            else { return ("Error de sintaxis. Se esperaba un 'fin' " + ImpresionRenglonFix()); }
            //else
            if (((Token)(tokens[cont])).No_token == 146)
            {
                if (cont < last) { cont++; }
                if (((Token)(tokens[cont])).No_token != 151) { if (cont < last) { cont++; } return ("Error de sintaxis. Se esperaba un 'inicio'. " + ImpresionRenglonFix()); }
                if (cont < last) { cont++; }
                while (((Token)(tokens[cont])).No_token != 152 && cont < last)
                {
                    Mensaje = instrucciones(((Token)(tokens[cont])).No_token);
                    if (!Mensaje.Equals("")) { return Mensaje; }
                    //if (!(cont <= last)) { break; }
                }
                if (cont < last) { cont++; }
                else { return ("Error de sintaxis. Se esperaba un 'fin'. " + ImpresionRenglonFix()); }
            }
            return Mensaje;
        }
        public String LlamadaFuncion()
        {
            Token valor;
            AnalisisSemantico AuxSemantica = new AnalisisSemantico();
            int last = tokens.Count - 1;//último token registrado
                                        //Console.Write(((Token)(tokens[cont])).No_token
                                        //

            int variable = (int)TipoFuncion[IndexOfFuncion(((Token)(tokens[cont])).Simbolo)];
            if (cont < last) { cont++; }
            if (((Token)(tokens[cont])).No_token != 160) { return ("Error de sintaxis. Se esperaba '('. " + ImpresionRenglonFix()); }
            if (cont < last) { cont++; }
            bool ban = false;
            do
            {
                ban = true;


                if (((Token)(tokens[cont])).No_token != 159 && ((Token)(tokens[cont])).No_token != 101 && ((Token)(tokens[cont])).No_token != 102 && ((Token)(tokens[cont])).No_token != 103)
                {
                    if (((Token)(tokens[cont])).No_token == 161)
                    {
                        if (cont < last) { cont++; }
                        break;
                    }
                    return ("Error de sintaxis. Se esperaba asignar un valor. " + ImpresionRenglonFix());
                }
                if (((Token)(tokens[cont])).No_token == 103)
                {
                    if (variables.Contains(((Token)(tokens[cont])).Simbolo) != true) { return ("Error de semantica. La variable no ha sido declarada anteriormente. " + ImpresionRenglonFix()); }
                }
                valor = (Token)tokens[cont];
                int TipoValor = 0;
                if (valor.No_token == 103)
                {
                    TipoValor = (int)TipoVariable[IndexOfVariable(valor.Simbolo)];
                }
                Mensaje = AuxSemantica.Asignacion(variable, valor, TipoValor);
                if (!Mensaje.Equals("")) { return Mensaje; }
                if (cont < last) { cont++; }


                if (((Token)(tokens[cont])).No_token != 162 && ((Token)(tokens[cont])).No_token != 104 && ((Token)(tokens[cont])).No_token != 105 && ((Token)(tokens[cont])).No_token != 106 && ((Token)(tokens[cont])).No_token != 107)
                {
                    if (((Token)(tokens[cont])).No_token != 161)
                    {
                        return ("Error de sintaxis. Se esperaba ')'." + ImpresionRenglonFix());
                    }
                    else
                    {
                        ban = false;
                    }
                }
                if (cont < last) { cont++; }

                else { ban = false; }

            } while (ban);


            if (((Token)(tokens[cont])).No_token != 130) { return ("Error de sintaxis. Se esperaba ';'. " + ImpresionRenglonFix()); }
            if (cont < last) { cont++; }
            return Mensaje;
        }

        public String escribir()
        {
            int last = tokens.Count - 1;//último token registrado
                                        //Console.Write(((Token)(tokens[cont])).No_token);

            if (((Token)(tokens[cont])).No_token != 160) { return ("Error de sintaxis. Se esperaba '('. " + ImpresionRenglonFix() ); }
            if (cont < last) { cont++; }
            bool ban = false;
            do
            {
                if (((Token)(tokens[cont])).No_token != 159 && ((Token)(tokens[cont])).No_token != 103)
                { return ("Error de sintaxis. Se esperaba una cadena " + ImpresionRenglonFix()); }
                //preguntamos si la variable existe 
                if (((Token)(tokens[cont])).No_token == 103)
                {
                    if (variables.Contains(((Token)(tokens[cont])).Simbolo) != true) { return ("Error de semantica. La variable no ha sido declarada anteriormente. " + ImpresionRenglonFix() ); }
                }

                if (cont < last) { cont++; }
                if (((Token)(tokens[cont])).No_token == 162) { cont++; ban = false; } else { ban = true; }

            } while (ban == false);


            if (((Token)(tokens[cont])).No_token != 161) { return ("Error de sintaxis. Se esperaba ')'. " + ImpresionRenglonFix() ); }
            if (cont < last) { cont++; }
            if (((Token)(tokens[cont])).No_token != 130) { return ("Error de sintaxis. Se esperaba ';'. " + ImpresionRenglonFix() ); }
            if (cont < last) { cont++; }
            return Mensaje;
        }
        public String leer()
        {
            int last = tokens.Count - 1;//último token registrado

            if (((Token)(tokens[cont])).No_token != 160) { return ("Error de sintaxis. Se esperaba '('. " + ImpresionRenglonFix() );  }
            if (cont < last) { cont++; }
            if (((Token)(tokens[cont])).No_token != 103) { return ("Error de sintaxis. se esperaba identificador par leer. " + ImpresionRenglonFix()); }
            if (variables.Contains(((Token)(tokens[cont])).Simbolo) != true) { return ("Error de semantica. La variable no ha sido declarada anteriormente. " + ImpresionRenglonFix() ); }
            if (cont < last) { cont++; }
            if (((Token)(tokens[cont])).No_token != 161) { return ("Error de sintaxis. Se esperaba ')'. " + ImpresionRenglonFix() ); }
            if (cont < last) { cont++; }
            if (((Token)(tokens[cont])).No_token != 130) { return ("Error de sintaxis. Se esperaba ';'. " + ImpresionRenglonFix() ); }
            if (cont < last) { cont++; }
            return Mensaje;
        }


        //////////////EXPRESION\\\\\\\\\\\\\\\
        public string Expresion()
        {
            int last = tokens.Count - 1;//último token registrado
            Mensaje = Exp_simp();
            if (!Mensaje.Equals("")) { return Mensaje; }
            if (((Token)(tokens[cont])).No_token != 118 && ((Token)(tokens[cont])).No_token != 119 && ((Token)(tokens[cont])).No_token != 120 && ((Token)(tokens[cont])).No_token != 121
                   && ((Token)(tokens[cont])).No_token != 122 && ((Token)(tokens[cont])).No_token != 123)
            {

                return ("Error de sintaxis. Se esperaba operador logico. " + ImpresionRenglonFix());
            }
            if (cont < last) { cont++; }
            Mensaje = Exp_simp();
            if (!Mensaje.Equals("")) { return Mensaje; }

            return "";
        }
        public string Exp_simp()
        {
            int last = tokens.Count - 1;//último token registrado
            bool permitir = true;
            if (((Token)(tokens[cont])).No_token == 104 || ((Token)(tokens[cont])).No_token == 105 || ((Token)(tokens[cont])).No_token == 126)
            {
                if (cont < last) { cont++; }
            }
            while (permitir)
            {
                Mensaje = Termino();
                if (!Mensaje.Equals("")) { return Mensaje; }

                if (((Token)(tokens[cont])).No_token == 104 || ((Token)(tokens[cont])).No_token == 105 || ((Token)(tokens[cont])).No_token == 125)
                {
                    if (cont < last) { cont++; }
                }
                else
                {
                    permitir = false;
                }
            }

            return "";
        }
        public string Termino()
        {
            int last = tokens.Count - 1;//último token registrado
            bool permitir = true;
            while (permitir)
            {
                Mensaje = Factor();
                if (!Mensaje.Equals("")) { return Mensaje; }
                if (cont < last) { cont++; }
                if (((Token)(tokens[cont])).No_token == 107 || ((Token)(tokens[cont])).No_token == 106 || ((Token)(tokens[cont])).No_token == 111 || ((Token)(tokens[cont])).No_token == 108 || ((Token)(tokens[cont])).No_token == 124)
                {
                    if (cont < last) { cont++; }
                }
                else
                {
                    permitir = false;
                }
            }
            
            return "";
        }
        public string Factor()
        {
            int last = tokens.Count - 1;//último token registrado
            if (((Token)(tokens[cont])).No_token != 160  && ((Token)(tokens[cont])).No_token != 159 && 
                ((Token)(tokens[cont])).No_token != 101 && ((Token)(tokens[cont])).No_token != 102 && ((Token)(tokens[cont])).No_token != 103)
            {
                return ("Error de sintaxis. Factor. " + ImpresionRenglonFix());
            }
            else
            {
                if (((Token)(tokens[cont])).No_token == 103)
                {
                    if (variables.Contains(((Token)(tokens[cont])).Simbolo) != true) { return ("Error de semantica. La variable no ha sido declarada anteriormente. " + ImpresionRenglonFix()); }
                }


                if (((Token)(tokens[cont])).No_token == 160)
                {
                    if (cont < last) { cont++; }
                    Mensaje = Expresion();
                    if (!Mensaje.Equals("")) { return Mensaje; }
                    if (((Token)(tokens[cont])).No_token != 161)
                    {
                        return ("Error de sintaxis. Se esperaba ')'. " + ImpresionRenglonFix());
                    }
                }
            }
            return "";
        }
    }
}
