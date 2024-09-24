import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ClienteService, Cliente, Porte, ApiResponse, ApiError } from './services/cliente.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Cadastro Clientes';

  clientes: Cliente[] = [];
  porteValores = Object.keys(Porte).filter(key => isNaN(Number(key)));
  errorMessage: string | null = null;

  idCliente: number = 0;
  nomeCliente: string = "";
  porteCliente: Porte = 0;

  constructor(private clienteService: ClienteService) { }

  ngOnInit(): void {
    this.carregarListaClientes();
  }

  carregarListaClientes(): void {
    this.clienteService.getClientes().subscribe(
      (response: ApiResponse) => {
        if (response.isSuccess) {
          this.clientes = response.value;
        } else if (response.error) {
          this.errorMessage = `Erro: ${response.error.code} - ${response.error.message}`;
        }
      },
      (httpResponseError: any) => {
        console.error('Erro ao carregar clientes', httpResponseError.error.detail);
      });
  }

  salvarDadosCliente(): void {
    let cliente: any = {
      nome: this.nomeCliente,
      porte: this.porteCliente
    };

    if (this.idCliente != 0) {
      this.clienteService.updateCliente(this.idCliente, cliente).subscribe(
        () => {
          this.carregarListaClientes();
          this.idCliente = 0;
          this.nomeCliente = "";
          this.porteCliente = 0;
        },
        (httpResponseError: any) => {
          console.error('Erro ao atualizar os dados clientes', httpResponseError.error.detail);
        });
    } else {
      this.clienteService.createCliente(cliente).subscribe(
        () => {
          this.carregarListaClientes();
          this.nomeCliente = "";
          this.porteCliente = 0;
        },
        (httpResponseError: any) => {
          console.error('Erro ao salvar os dados clientes', httpResponseError.error.detail);
        });
    }
  }

  preencherFormulario(id: number, nome: string, porte: Porte): void {
    this.idCliente = id;
    this.nomeCliente = nome;
    this.porteCliente = porte;
  }

  excluirCliente(id: number): void {
    if(confirm("Deseja excluir o cliente?")){
      this.clienteService.deleteCliente(id).subscribe(
        () => {
          this.carregarListaClientes();
        },
        (httpResponseError: any) => {
          console.error('Erro ao excluir clientes', httpResponseError.error.detail);
        });
    }
  }
}
