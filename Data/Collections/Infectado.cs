using System;
namespace Api.Data.Collections
{
    public class Infectado
    {

        public Infectado(DateTime dataNascimento, string sexo, double latitude, double longitude)
        {
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Localizacao = new GeoJson2DgeographicCoordinates(longitude, latitude);
        }
    }
}