using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            try
            {
                // Verifica se a capacidade é suficiente para acomodar todos os hóspedes
                if (Suite.Capacidade >= hospedes.Count)
                {
                    // Atribui a lista de hóspedes à propriedade Hospedes
                    Hospedes = hospedes;
                }
                else
                {
                    // Lança uma exceção indicando que a capacidade da suite é menor que o número de hóspedes
                    throw new Exception("Capacidade da suite menor que o número de hóspedes.");
                }
            }
            catch (Exception ex)
            {
                // Trata a exceção (pode ser log, exibição de mensagem, etc.)
                Console.WriteLine($"Erro ao cadastrar hóspedes: {ex.Message}");
                // Lança a exceção para que o chamador possa lidar com ela
                throw;
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            int qtdHospedes = Hospedes.Count;
            return qtdHospedes;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valor = 0;
            decimal desconto = 0.1m;
            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (DiasReservados >= 10)
            {
                valor = (Suite.ValorDiaria * DiasReservados) * (1 - desconto);
            }else
            {
                valor = Suite.ValorDiaria * DiasReservados;
            }

            return valor;
        }
    }
}