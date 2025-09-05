namespace EjerciciosHttps.Models
{
    public class CuentaBancaria
    {
        private decimal saldo;

        public CuentaBancaria(decimal saldoInicial)
        {
            saldo = saldoInicial >= 0 ? saldoInicial : 0;
        }

        public decimal Saldo => saldo; 

        public bool Depositar(decimal monto)
        {
            if (monto <= 0) return false;
            saldo += monto;
            return true;
        }
    }
}
