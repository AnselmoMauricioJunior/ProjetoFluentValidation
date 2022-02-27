namespace ApiProjetoFluentValidation.Core.Models
{
    public class Planta
    {
        public int ID { get; private set; }
        public string nome { get; private set; }
        public int luzdiaria { get; private set; }
        public int agua { get; private set; }
        public int peso { get; private set; }

        protected Planta() { }
        public Planta(string nome, int luzdiaria, int agua, int peso)
        {
            this.nome = nome;
            this.luzdiaria = luzdiaria;
            this.agua = agua;
            this.peso = peso;
        }

        public Planta(string nome)
        {
            this.nome = nome;
            luzdiaria = 0;
            agua = 0;
            peso = 0;
        }

        public Planta(int id)
        {
            ID = id;
            nome = "";
            luzdiaria = 0;
            agua = 0;
            peso = 0;
        }
    }
}
