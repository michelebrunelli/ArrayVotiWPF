using System;
using System.Globalization;

namespace GestioneVoti
{
    public enum TipoVoto
    {
        Orale = 0,
        Scritto = 1,
        Pratico = 2,
    }

    public enum Materia
    {
        Italiano = 0,
        Inglese = 1,
        Informatica = 2,
        Matematica = 3,
        Telecomunicazioni = 4,
        Tecnologie = 5,
        Sistemi = 6,
        Ginnastica = 7,
    }


    public enum TipoVoce
    {
        Voto = 0,
        Materia = 1,
        Tipo = 2,
        Data = 3,

    }

    public class Voto : IComparable
    {
        public float Valore { get; set; }
        public TipoVoto Tipo { get; set; }
        public DateTime Data { get; set; }
        public Materia Materia { get; set; }

        public Voto(Materia materia, TipoVoto tipo, float voto, DateTime data)
        {
            Valore = voto;
            Tipo = tipo;
            Data = data;
            Materia = materia;
        }

        int IComparable.CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
    public class Voti
    {
        public int DimensioneMassima { get; set; }
        private readonly Voto[] _voti;
        private int _dimensione = 0;

        public Voti() : this(50)
        {
            
        }

        public Voti(int dimensioneMassima)
        {
            DimensioneMassima = dimensioneMassima;
            _voti = new Voto[DimensioneMassima];
            _dimensione = 0;
        }

        public Voto[] DammiIVoti()
        {
            return _voti;
        }
        public Voti InserisciVoto(Materia materia, TipoVoto tipo, float voto, DateTime dataora)
        {
            if (_dimensione <= DimensioneMassima)
            {
                _voti[_dimensione] = new Voto(materia, tipo, voto, dataora);
                _dimensione++;
                return this;
            }
            return null;
        }

        public Voti CancellaVoto(int posizione)
        {
            if (!IndiceValido(posizione)) return null;
            for (var i = posizione - 1; i < _dimensione; i++)
            {
                _voti[i] = _voti[i + i];
                _dimensione--;
            }
            return this;
        }

        public float Media(Materia materia)
        {
            float sum = 0;
            int dim = 0;
            for (var i = 0; i < _dimensione; i++)
            {
                if (_voti[i].Materia == materia)
                {
                    sum += _voti[i].Valore;
                    dim++;
                }
            }
            return dim == 0 ? 0 : sum / dim;
        }

        private bool IndiceValido(int i)
        {
            return i >= 0 && i <= _dimensione && _dimensione > 0;
        }
        private int Confronta(TipoVoce voce, int i, int k)
        {
            if (!IndiceValido(i)) throw new ArgumentOutOfRangeException("i", i, null);
            if (!IndiceValido(k)) throw new ArgumentOutOfRangeException("k", k, null);
            switch (voce)
            {
                case TipoVoce.Voto:
                    return (_voti[i].Valore < _voti[k].Valore) ? -1 : (_voti[i].Valore > _voti[k].Valore) ? 1 : 0;
                    break;
                case TipoVoce.Tipo:
                    return (_voti[i].Tipo < _voti[k].Tipo) ? -1 : (_voti[i].Tipo > _voti[k].Tipo) ? 1 : 0;
                    break;
                case TipoVoce.Data:
                    return (_voti[i].Data < _voti[k].Data) ? -1 : (_voti[i].Data > _voti[k].Data) ? 1 : 0;
                    break;
                case TipoVoce.Materia:
                    return (_voti[i].Materia.CompareTo(_voti[k].Materia));
                    break;
                default:
                    throw new ArgumentOutOfRangeException("voce", voce, null);
            }
        }

        private Voti Scambia(int i, int k)
        {
            if (IndiceValido(i) && IndiceValido(k))
            {
                var voto = _voti[i];
                _voti[i] = _voti[k];
                _voti[k] = voto;
                return this;
            }
            return null;

        }
        public Voti Ordina(TipoVoce voce)
        {
            for (var i = 0; i < _dimensione; i++)
            {
                var minimo = i;
                for (var j = i + 1; j < _dimensione; j++)
                {
                    if (Confronta(voce, j, i) < 0)
                        minimo = j;
                }
                if (minimo != i)
                    Scambia(minimo, i);
            }
            return this;
        }

    }
}