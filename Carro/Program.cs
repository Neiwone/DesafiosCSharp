using System.ComponentModel.DataAnnotations;
using System.Text;

class Carro
{
    private string _placa;
    private string _modelo;
    private Motor _motor;

    [Required(ErrorMessage = "A Placa do Carro é obrigatoria")]
    public string Placa 
    {
        get { return _placa; } 
        private set { _placa = value; }
    }

    [Required(ErrorMessage = "O Modelo do Carro é obrigatorio")]
    public string Modelo
    { 
        get { return _modelo; }
        private set { _modelo = value; } 
    }

    [Required(ErrorMessage = "O Motor do Carro é obrigatorio")]
    public Motor Motor
    { 
        get { return _motor; } 
        set 
        {
            if (value.instalado == true) throw new Exception("Motor ja esta instalado em outro Carro");
            _motor.instalado = false; 
            _motor = value; 
            Validate();
            _motor.instalado = true;
        } 
    }

    public void Validate()
    {
        ValidationContext context = new ValidationContext(this);
        List<ValidationResult> results = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(this, context, results, true);

        if (!isValid)
        {
            StringBuilder sbrErrors = new StringBuilder();
            foreach (var validationResult in results)
            {
                sbrErrors.AppendLine(validationResult.ErrorMessage);
            }
            throw new ValidationException(sbrErrors.ToString());
        }
    }

    public Carro(string placa, string modelo, Motor motor)
    {
        Placa = placa;
        Modelo = modelo;
        Motor = motor;

        Validate();

        motor.instalado = true;
    }

    public int VelocidadeMaxima()
    {
        if (Motor.Cilindrada <= 1.0) return 140;
        else if (Motor.Cilindrada <= 1.6) return 160;
        else if(Motor.Cilindrada <= 2.0) return 180;
        else return 220;
    }
}

class Motor
{
    private double _cilindrada;

    [Required]
    public double Cilindrada
    {
        get { return _cilindrada;  }
        private set { _cilindrada = value; }
    }

    public bool instalado = false;
}