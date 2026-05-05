using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaAluguerVeiculos
{
    public class Aluguer
    {
        
        public Veiculo Veiculo { get; set; }
        public Cliente Cliente { get; set; }

        public double KmInicial { get; set; }
        public double KmFinal { get; set; }

        public bool Activo { get; set; }

        public Aluguer(Veiculo veiculo, Cliente cliente)
        {
            Veiculo = veiculo;
            Cliente = cliente;
            KmInicial = veiculo.Quilometragem; 
            KmFinal = 0;
            Activo = true;
        }

        public void Finalizar(double kmPercorridos)
        {
            if (kmPercorridos <= 0)
            {
                Console.WriteLine("QUILOMETRAGEM INVÁLIDA!");
                return;
            }

            KmFinal = KmInicial + kmPercorridos;

            Veiculo.AtualizarKm(kmPercorridos);
            Veiculo.Disponivel = true;

            Activo = false;
        }

        public void Mostrar()
        {
            Console.WriteLine("\n===== ALUGUER =====");
            Console.WriteLine($"CLIENTE: {Cliente.Nome}");
            Console.WriteLine($"VEICULO: {Veiculo.Matricula}");
            Console.WriteLine($"KM INICIAL: {KmInicial}");
            Console.WriteLine($"KM FINAL: {(Activo ? "Em uso" : KmFinal.ToString())}");
            Console.WriteLine($"ESTADO: {(Activo ? "Ativo" : "Finalizado")}");
        }
    }
}
