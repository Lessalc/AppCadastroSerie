using System;
using DIO.Series.Enum;

namespace DIO.Series.Classes
{
    public class Serie : EntidadeBase, IComparable<Serie>
    {
        // Atributos
        public Genero Genero { get; set; }
        public string Titulo { get; set; }        
        public string Descricao { get; set; }        
        public int Ano { get; set; }
        private bool Excluido { get; set; }
        private double Rating { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano, double rating)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
            this.Rating = rating;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: "+ this.Genero + Environment.NewLine;
            retorno += "Titulo: "+ this.Titulo + Environment.NewLine;
            retorno += "Descricao: "+ this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: "+ this.Ano + Environment.NewLine;
            retorno += "Rating: "+ this.Rating + Environment.NewLine;
            retorno += "Excluida: "+ this.Excluido + Environment.NewLine;

            return retorno;
        }

        public string retornaTitulo(){
            return this.Titulo;
        }

        public int retornaId(){
            return this.Id;
        }

        public void Excluir(){
            this.Excluido = true;
        }

        public bool retornaExcluido(){
            return this.Excluido;
        }

        public double retornaRating(){
            return this.Rating;
        }

        public int CompareTo(Serie serie)
        {
            return this.Rating.CompareTo(serie.Rating);
        }
    }
}