using System.Collections;

namespace matriz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public ArrayList tokens = new ArrayList();
        Token token = new Token();
        Error error = new Error();
        public ArrayList errores = new ArrayList();
        
        
        int[,] Matriz = new int[26, 27]
          //  0      1    2      3    4     5     6     7         8    9    10    11    12    13    14    15    16    17    18   19     20    21    22      23       24    25      26
        { // 0…9   e.E    .     _     +     -     =     /    EOF-EOL   *     ^     %     : 	   >     <     Y     O     N    ""     (     )    ;   Espacio  a…z,A…Z   O.C    /n     ,
            {  1,    7,   19,    7,    8,    9,   18,   10,      0,   14,  108,  111,   15,   16,   17,    7,    7,    7,   24,  160,  161,  130,       0,      7,   -10,    0,  162},//0
            {  1,    2,    4,  101,  101,  101,  101,  101,     101,  101,  101,  101,  101,  101,  101,  101,  101,  101,  101,  101,  101,  101,     101,    101,  101,  101,  101},//1
            {  3,  - 1,  - 1,   -1,  - 1,  - 1,  - 1,  - 1,     - 1,  - 1,  - 1,  - 1,  - 1,  - 1,  - 1,  - 1,  - 1,  - 1,   -1,   -1,   -1,   -1,      -1,     -1,  - 1,   -1,   -1},//2
            {  3,  101,  101,  101,  101,  101,  101,  101,     101,  101,  101,  101,  101,  101,  101,  101,  101,  101,  101,  101,  101,  101,     101,    101,  101,  101,  101},//3
            {  5,  - 2,  - 2,  - 2,  - 2,  - 2,  - 2,  - 2,     - 2,  - 2,  - 2,  - 2,  - 2,  - 2,  - 2,  - 2,  - 2,  - 2,   -2,   -2,   -2,   -2,      -2,     -2,  - 2,   -2,   -2},//4
            {  5,  102,  102,  102,  102,  102,  102,  102,     102,  102,  102,  102,  102,  102,  102,  102,  102,  102,  102,  102,  102,  102,     102,    102,  102,  102,  102},//5
            {  5,  - 2,  - 2,  - 2,  - 2,  - 2,  - 2,  - 2,     - 2,  - 2,  - 2,  - 2,  - 2,  - 2,  - 2,  - 2,  - 2,  - 2,   -2,   -2,   -2,   -2,      -2,     -2,  - 2,   -2,   -2},//6
            {  7,    7,  103,    7,  103,  103,  103,  103,     103,  103,  103,  103,  103,  103,  103,    7,    7,    7,  103,  103,  103,  103,     103,      7,  103,  103,  103},//7
            {104,  104,  104,  104,  109,  104,  113,  104,     104,  104,  104,  104,  104,  104,  104,  104,  104,  104,  104,  104,  104,  104,     104,    104,  104,  104,  104},//8
            {105,  105,  105,  105,  105,  110,  114,  105,     105,  105,  105,  105,  105,  105,  105,  105,  105,   10,  105,  105,  105,  105,     105,    105,  105,  105,  105},//9
            {106,  106,  106,  106,  106,  106,  116,   25,     106,   12,  106,  106,  106,  106,  106,  106,  106,  106,  106,  106,  106,  106,     106,    106,  106,  106,  106},//10
            { 11,   11,   11,   11,   11,   11,   11,   11,     117,   11,   11,   11,   11,   11,   11,   11,   11,   11,   11,   11,   11,   11,      11,     11,   11,   11,   11},//11
            { 12,   12,   12,   12,   12,   12,   12,   12,     - 3,   13,   12,   12,   12,   12,   12,   12,   12,   12,   12,   12,   12,   12,      12,     12,   12,   12,   12},//12
            { 12,   12,   12,   12,   12,   12,   12,  128,     - 3,   12,   12,   12,   12,   12,   12,   12,   12,   12,   12,   12,   12,   12,      12,     12,   12,   12,   12},//13
            {107,  107,  107,  107,  107,  107,  115,  107,     107,  107,  107,  107,  107,  107,  107,  107,  107,  107,  107,  107,  107,  107,     107,    107,  107,  107,  107},//14
            {- 4,   -4,  - 4,  - 4,  - 4,  - 4,  112,  - 4,     - 4,  - 4,  - 4,  - 4,  - 4,  - 4,  - 4,  - 4,  - 4,  - 4,   -4,   -4,   -4,   -4,      -4,     -4,  - 4,   -4,   -4},//15
            {118,  118,  118,  118,  118,  118,  120,  118,     118,  118,  118,  118,  118,  118,  118,  118,  118,  118,  118,  118,  118,  118,     118,    118,  118,  118,  118},//16
            {119,  119,  119,  119,  119,  119,  121,  119,     119,  119,  119,  119,  119,  122,  119,  119,  119,  119,  119,  119,  119,  119,     119,    119,  119,  119,  119},//17
            {- 5,  - 5,  - 5,  - 5,  - 5,  - 5,  123,  - 5,     - 5,  - 5,  - 5,  - 5,  - 5,  - 5,  - 5,  - 5,  - 5,  - 5,   -5,   -5,   -5,   -5,      -5,     -5,  - 5,   -5,   -5},//18
            {- 8,  - 8,  - 8,  - 8,  - 8,  - 8,  - 8,  - 8,     - 8,  - 8,  - 8,  - 8,  - 8,  - 8,  - 8,   20,   21,   22,  - 8,  - 8,  - 8,  - 8,     - 8,    - 8,  - 8,  - 8,   -8},//19
            {- 6,  - 6,  124,  - 6,  - 6,  - 6,  - 6,  - 6,     - 6,  - 6,  - 6,  - 6,  - 6,  - 6,  - 6,  - 6,  - 6,  - 6,   -6,   -6,   -6,   -6,      -6,     -6,  - 6,   -6,   -6},//20
            {- 6,  - 6,  125,  - 6,  - 6,  - 6,  - 6,  - 6,     - 6,  - 6,  - 6,  - 6,  - 6,  - 6,  - 6,  - 6,  - 6,  - 6,   -6,   -6,   -6,   -6,      -6,     -6,  - 6,   -6,   -6},//21
            {- 7,  - 7,  - 7,  - 7,  - 7,  - 7,  - 7,  - 7,     - 7,  - 7,  - 7,  - 7,  - 7,  - 7,  - 7,  - 7,   23,  - 7,   -7,   -7,   -7,   -7,      -7,     -7,  - 7,   -7,   -7},//22
            {- 6,  - 6,  126,  - 6,  - 6,  - 6,  - 6,  - 6,     - 6,  - 6,  - 6,  - 6,  - 6,  - 6,  - 6,  - 6,  - 6,  - 6,   -6,   -6,   -6,   -6,      -6,     -6,  - 6,   -6,   -6},//23
            { 24,   24,   24,   24,    24,  24,   24,   24,     - 9,   24,   24,   24,   24,   24,   24,   24,   24,   24,  159,   24,   24,   24,     24,     24,   -3,    24,   24},//24
            { 25,   25,   25,   25,    25,  25,   25,   25,      25,   25,   25,   25,   25,   25,   25,   25,   25,   25,    25,   25,   25,   25,     25,     25,   25,  127,   25}//25
        };
        

        public void AnalizadorLexico(string[] LineasDeTexto, bool escribir)
        {
            if (escribir)
            {
                richTextBox1.Text = "";
            }

            int estado = 0; //aqui indicamos en qué estado estamos
            int columna = 0;//columna de la matriz o caracter leído
            int renglon = 0;//renglon
            int i = 0;
            char Caracter = ' ';

            string palabra = "";
            bool leer = true; //comprobaremos la lectura para evitar perder tokens generados     
            bool terminar = false;
            bool terminado = false;

            foreach (string arreglo in LineasDeTexto) //leyendo lineas
            {
                renglon++;
                i = 0;
                leer = true;
                terminar = false;

                while (!terminar) //leyendo caracteres
                {

                    if (i < arreglo.Length && leer == true)
                    {
                        Caracter = arreglo[i];
                        i++;
                        terminar = false;
                    }
                    else if (leer == true)
                    {
                        Caracter = (char)10;
                        terminar = true;
                    }

                    switch (Caracter)
                    {

                        case char resulfin when (resulfin >= 48 && resulfin <= 57): { columna = 0; break; }//NUMEROS
                        case char resulfin when (resulfin == 69): { columna = 1; break; }//E
                        case char resulfin when (resulfin == 101): { columna = 1; break; }//e
                        case char resulfin when (resulfin == 46): { columna = 2; break; }//punto .
                        case char resulfin when (resulfin == 95): { columna = 3; break; }//GBAJO _
                        case char resulfin when (resulfin == 43): { columna = 4; break; }//SUMA +
                        case char resulfin when (resulfin == 45): { columna = 5; break; }//guion -
                        case char resulfin when (resulfin == 61): { columna = 6; break; }//IGUAL =
                        case char resulfin when (resulfin == 47): { columna = 7; break; }// diagonal /
                        case char resulfin when (resulfin == 03): { columna = 8; break; }// ETX: FIN DE TEXTO
                        case char resulfin when (resulfin == 42): { columna = 9; break; }// ASTERISCO *
                        case char resulfin when (resulfin == 94): { columna = 10; break; }//POTENCIA ^
                        case char resulfin when (resulfin == 37): { columna = 11; break; }// %
                        case char resulfin when (resulfin == 58): { columna = 12; break; }// dos puntos :
                        case char resulfin when (resulfin == 62): { columna = 13; break; }// >
                        case char resulfin when (resulfin == 60): { columna = 14; break; }// <

                        case char resulfin when (resulfin == 89): { columna = 15; break; }//Y
                        case char resulfin when (resulfin == 79): { columna = 16; break; }//O
                        case char resulfin when (resulfin == 78): { columna = 17; break; }//N

                        case char resulfin when (resulfin == 34): { columna = 18; break; }// "
                        case char resulfin when (resulfin == 40): { columna = 19; break; }// (
                        case char resulfin when (resulfin == 41): { columna = 20; break; }// )
                        case char resulfin when (resulfin == 59): { columna = 21; break; }// ;
                        case char resulfin when (resulfin == 32): { columna = 22; break; }// espacio en blanco
                        case char resulfin when (resulfin == 9): { columna = 22; break; }// tab /t 
                        case char resulfin when (resulfin == 10): { columna = 25; break; }// salto de linea

                        case char resulfin when (resulfin >= 97 && resulfin <= 122): { columna = 23; break; }//LETRAS MINUSCULAS
                        case char resulfin when (resulfin >= 65 && resulfin <= 90): { columna = 23; break; }//LETRAS MAYUSCULAS
                        case char resulfin when (resulfin == 44): { columna = 26; break; }// ,



                        /*
                         *  case char resulfin when (resulfin == 39): { columna = 7; break; }//apóstrofe '
                       
                        case char resulfin when (resulfin == 33): { columna = 18; break; }// !
                        
                        
                        case char resulfin when (resulfin == 123): { columna = 22; break; }// {
                        case char resulfin when (resulfin == 125): { columna = 23; break; }// }
                        case char resulfin when (resulfin == 91): { columna = 24; break; }// [
                        case char resulfin when (resulfin == 93): { columna = 25; break; }// ]
                        case char resulfin when (resulfin == 38): { columna = 26; break; }// &
                        case char resulfin when (resulfin == 124): { columna = 27; break; }// |
                        case char resulfin when (resulfin == 10): { columna = 28; break; }// salto de linea
                        case char resulfin when (resulfin == 13): { columna = 29; break; }// Retorno de carro /r
                       
                       
                        */

                        case char resulfin when (resulfin == 35): { columna = 24; break; }// #
                        case char resulfin when (resulfin == 36): { columna = 24; break; }// $
                        case char resulfin when (resulfin == 68): { columna = 24; break; }// ?
                        case char resulfin when (resulfin == 64): { columna = 24; break; }// @
                        case char resulfin when (resulfin == 96): { columna = 24; break; }// `
                        case char resulfin when (resulfin == 126): { columna = 24; break; }// ~
                        case char resulfin when (resulfin == 172): { columna = 24; break; }// ¬
                        case char resulfin when (resulfin == 176): { columna = 24; break; }// °
                        //case char resulfin when (resulfin == 36): { columna = 33; break; }// ¨
                        //case char resulfin when (resulfin == 36): { columna = 33; break; }// ´
                        case char resulfin when (resulfin == 191): { columna = 24; break; }// ¿
                        case char resulfin when (resulfin == 165): { columna = 24; break; }// ÑÑÑÑÑÑÑÑÑÑÑÑÑÑ
                        case char resulfin when (resulfin == 164): { columna = 24; break; }// ññññññññññññññ

                            //
                            default: { columna = 24; break; }
                    }
                    if (LineasDeTexto.Count() == renglon && i == arreglo.Length)
                    {
                        if (terminado)
                        {
                            estado = Matriz[estado, 8];
                        }
                        else
                        {
                            estado = Matriz[estado, columna];
                        }
                        terminado = true;


                    }
                    else
                    {
                        estado = Matriz[estado, columna];
                    }
                    
                   

                    if (estado < 0)
                    {
                        error = new Error();
                        error.No_error = estado;
                        error.Columna = i;
                        error.Fila = renglon;
                        if (palabra == "")
                        {
                            error.Simbolo = Convert.ToString(Caracter);
                        }
                        else
                        {
                            i--;
                            error.Simbolo = palabra;
                            palabra = "";
                        }
                        errores.Add(error);
                        estado = 0;
                    }

                    if ((estado != 103 && estado != 102 && estado != 101 && estado != 106 && estado != 107 && estado != 140 && estado != 104 &&
                        estado != 105 && estado != 118 && estado != 119))
                    { leer = true; }
                    else { leer = false; }

                    if (leer == true)
                    {
                        if (estado > 0)
                        {
                            if ((Caracter != 32 && Caracter != 10 && Caracter != 9 && Caracter != 13) || estado == 24 || estado == 25 || estado == 12 || estado == 13)
                            { palabra = palabra + Caracter; }
                        }
                    }
                    else
                    {
                        terminado = false;
                    }
                    if (escribir && (leer == true || Caracter == 10))
                    {
                        String textarea = richTextBox1.Text;
                        textarea = textarea + Caracter;
                        richTextBox1.Text = textarea;
                    }

                    if (estado > 100)
                    {
                        if (estado == 159)
                        {
                            palabra = palabra.Remove(0, 1);
                            palabra = palabra.Remove(palabra.Length - 1, 1);
                        }
                        token = new Token();
                        token.Renglon = renglon;
                        token.Columna = i;
                        if (Reservadas(palabra) != 0)
                        { token.No_token = Reservadas(palabra); }
                        else { token.No_token = estado; }
                        token.Simbolo = palabra;
                        token.ID = tokens.Count + 1;
                        tokens.Add(token);

                        estado = 0;
                        palabra = "";//regresamos a la posicion 0 del arreglo
                        if (i == arreglo.Length && leer == false) { i = arreglo.Length - 1; leer = true; } //else { i++; }

                    }
                }
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public String ContextoError(int error)
        {
            String Error = "";
            switch (error)
            {
                case -1: { Error = "Esperaba finalizar con números."; break; }
                case -2: { Error = "faltan números después del punto."; break; }
                case -3: { Error = "Comentarios no cerrados"; break; }
                case -4: { Error = "Se esperaba asignacion '='"; break; }
                case -5: { Error = "Se esperaba comparación =="; break; }
                case -6: { Error = "Se esperaba punto en operador logico"; break; }
                case -7: { Error = "Se esperaba O en operador logico .NO."; break; }
                case -8: { Error = "Se esperaba operador logico Y O NO"; break; }
                case -9: { Error = "Comillas no cerradas"; break; }
                case -10: { Error = "Caracter no valido"; break; }
            }
            return Error;
        }
        public int Reservadas(string palabra)
        {
            int token = 0;
            switch (palabra)
            {
                case "entero": { token = 140; break; }
                case "real": { token = 141; break; }
                case "boleano": { token = 142; break; }
                case "cadena": { token = 143; break; }
                case "si": { token = 144; break; }
                case "entonces": { token = 145; break; }
                case "sino": { token = 146; break; }
                case "hasta": { token = 147; break; }
                case "hacer": { token = 148; break; }
                case "mientras": { token = 149; break; }
                case "funcion": { token = 150; break; }
                case "inicio": { token = 151; break; }
                case "fin": { token = 152; break; }
                case "leer": { token = 153; break; }
                case "escribir": { token = 154; break; }
                case "desde": { token = 155; break; }
                case "regresa": { token = 156; break; }
                case "programa": { token = 157; break; }
            }

            return token;
        }
        public string ReverseReservadas(int token)
        {
            string simbolo = "";
            switch (token)
            {
                case 140: { simbolo = "entero"; break; }
                case 141: { simbolo = "real"; break; }
                case 142: { simbolo = "boleano"; break; }
                case 143: { simbolo = "cadena"; break; }
                case 144: { simbolo = "si"; break; }
                case 145: { simbolo = "entonces"; break; }
                case 146: { simbolo = "sino"; break; }
                case 147: { simbolo = "hasta"; break; }
                case 148: { simbolo = "hacer"; break; }
                case 149: { simbolo = "mientras"; break; }
                case 150: { simbolo = "funcion"; break; }
                case 151: { simbolo = "inicio"; break; }
                case 152: { simbolo = "fin"; break; }
                case 153: { simbolo = "leer"; break; }
                case 154: { simbolo = "escribir"; break; }
                case 155: { simbolo = "desde"; break; }
                case 156: { simbolo = "regresa"; break; }
                case 157: { simbolo = "programa"; break; }
            }

            return simbolo;
        }
        public void ActualizarTabla()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            foreach (Token token in tokens)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = token.ID;
                row.Cells[1].Value = token.No_token;
                row.Cells[2].Value = token.Simbolo;
                row.Cells[3].Value = token.Renglon;
                row.Cells[4].Value = token.Columna;
                dataGridView1.Rows.Add(row);
            }
            foreach (Error error in errores)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[0].Clone();
                row.Cells[0].Value = error.No_error;
                row.Cells[1].Value = error.Simbolo;
                row.Cells[2].Value = error.Fila;
                row.Cells[3].Value = error.Columna;
                row.Cells[4].Value = ContextoError(error.No_error);


                dataGridView2.Rows.Add(row);
            }
            AnalisisText.Text = ("Tokens totales: " + tokens.Count +".\n");
            AnalisisSintactico AuxSintaxis = new AnalisisSintactico();
            String AnalisisMsg = AuxSintaxis.estructura(tokens);

            int auxcont = 0;
            foreach (object Simbolo in AuxSintaxis.Funciones)
            {

                DataGridViewRow row = (DataGridViewRow)dataGridView3.Rows[0].Clone();
                row.Cells[0].Value = auxcont + 1;
                row.Cells[1].Value = Simbolo.ToString();
                row.Cells[2].Value = "funcion " + ReverseReservadas((int)AuxSintaxis.TipoVariable[auxcont]);


                dataGridView3.Rows.Add(row);
                auxcont++;
                
            }
            int auxcont2 = 0;
            foreach (object Simbolo in AuxSintaxis.variables)
            {
                
                DataGridViewRow row = (DataGridViewRow)dataGridView3.Rows[0].Clone();
                row.Cells[0].Value = auxcont+1;
                row.Cells[1].Value = Simbolo.ToString();
                row.Cells[2].Value = ReverseReservadas((int)AuxSintaxis.TipoVariable[auxcont2]);


                dataGridView3.Rows.Add(row);
                auxcont++;
                auxcont2++;
            }
            
            

            AnalisisText.Text += AnalisisMsg;


            tokens.Clear();
            errores.Clear();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string Ruta = openFileDialog1.FileName;
                string[] Lineas = System.IO.File.ReadLines(@Ruta).ToArray();
                AnalizadorLexico(Lineas, true);
                ActualizarTabla();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado nada.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnalizadorLexico(richTextBox1.Lines, false);
            ActualizarTabla();
        }
        
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}