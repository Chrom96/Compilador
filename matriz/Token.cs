using System;
using System.Collections.Generic;
using System.Text;

namespace matriz
{
    class Token
    {
        int renglon, columna, no_token, id;
        string simbolo;

        public Token()
        {
            this.id = 0;
            this.renglon = 0;
            this.columna = 0;
            this.no_token = 0;
            this.simbolo = "";
        }
        public Token(int ID, int ren, int col, int ntoken, string sim)
        {
            this.id = ID;
            this.renglon = ren;
            this.columna = col;
            this.no_token = ntoken;
            this.simbolo = sim;
        }

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public int Renglon
        {
            get { return this.renglon; }
            set { this.renglon = value; }
        }
        public int Columna
        {
            get { return this.columna; }
            set { this.columna = value; }
        }
        public int No_token
        {
            get { return this.no_token; }
            set { this.no_token = value; }
        }
        public string Simbolo
        {
            get { return this.simbolo; }
            set { this.simbolo = value; }
        }
    }
}
