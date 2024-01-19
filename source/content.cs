bool validaChave(string CPF, string senhaInformada)
{
     int Soma = 0;
     string _CodigoGerado = CPF;
     string senha = "";
 
     var encodedBytes = ASCIIEncoding.ASCII.GetBytes(_CodigoGerado);
 
     for (int Idx = 1; Idx <= _CodigoGerado.Length; Idx++)
     {
         if ((Idx % 5) != 0)
             Soma = encodedBytes[Idx - 1] * 13;
         else if ((Idx % 3) != 0)
             Soma = encodedBytes[Idx - 1] * 9;
         else if ((Idx % 2) != 0)
             Soma = encodedBytes[Idx - 1] * 7;
         else
             Soma = encodedBytes[Idx - 1] * 3;
     }
 
     var inversao = new String(_CodigoGerado.Reverse().ToArray());
     decimal total = Soma * (int.Parse(DateTime.Now.ToString("yydd")) + int.Parse(DateTime.Now.ToString("HH")));
 
     senha = (total + Convert.ToInt64(inversao.Substring(0, total.ToString().Length))).ToString();
 
     if (senha != senhaInformada)
         return false;
 
     return true;
}