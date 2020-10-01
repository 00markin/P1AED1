using System;
using System.IO;

public class Relatorio{

	public void relatGastos(){
		if(File.Exists("Gastos.txt")){
			string[] relatGast = File.ReadAllLines("Gastos.txt");
			Console.WriteLine ("------------------------------------");
			for(int i = 0; i < relatGast.Length; i++){
				if (i%2 == 0){
					Console.WriteLine("Valor do gasto: R$"+relatGast[i]);
				}
				else {
					Console.WriteLine("Nome dado ao gasto: "+relatGast[i]);
					Console.WriteLine ("------------------------------------");
				}
			}
      Console.WriteLine("Para continuar tecle algo");
      Console.ReadKey();
		}
    else{
      Console.WriteLine("Não existem gastos registrados");
    }
	}

	public void gastoEsp(Carteira cart){
		DateTime StartDate = DateTime.Today;
		DateTime EndDate = new DateTime(StartDate.AddMonths(1).Year, StartDate.AddMonths(1).Month, cart.payday);
		Console.WriteLine("Gasto esperado diaramente: R$"+(cart.saldo/(EndDate - StartDate).TotalDays));
	}

	public void menuRelat(Carteira cart){
		int oprelat = 0;
	    while(oprelat!= 3){
	      Console.WriteLine ("------------------------------");
	      Console.WriteLine ("1 - RELATÓRIO DE GASTOS");
	      Console.WriteLine ("2 - GASTO DIARIO ESPERADO");
	      Console.WriteLine ("3 - SAIR");
	      Console.WriteLine ("------------------------------");
	      oprelat = int.Parse(Console.ReadLine());
	      switch(oprelat){
	        case 1:
	        Console.Clear();
	        relatGastos();
	        break;
	        case 2:
	        Console.Clear();
	        gastoEsp(cart);
	        break;
	        case 3:
	        Console.Clear();
	        break;
	        default:
	        Console.Clear();
	        Console.WriteLine("Opção inválida, tente novamente:");
	        break;
	    }
	}
	}
}