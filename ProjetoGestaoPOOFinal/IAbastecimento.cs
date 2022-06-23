

namespace ProjetoGestaoDeFrota
{
    interface IAbastecimento
    {
        /// <summary>
        /// Retorna o consumo do veículo (KM/L)
        /// </summary>
        /// <returns></returns>
        double consumo();
        /// <summary>
        /// Retorna o valor do litro do combustível
        /// </summary>
        /// <returns></returns>
        double valorLitro();
    }
}