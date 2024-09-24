import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// Interface para o Cliente
export interface Cliente {
  id: number;
  nome: string;
  porte: Porte;
}

export enum Porte {
  Pequena,
  Media,
  Grande
}

// Interface para o objeto de erro
export interface ApiError {
  code: string;
  message: string;
}

// Interface para o retorno da API
export interface ApiResponse {
  value: Cliente[];
  isSuccess: boolean;
  error: ApiError | null;
}

@Injectable({
  providedIn: 'root'
})

export class ClienteService {

  private apiUrl = 'https://localhost:7236';
  // private apiUrl = 'http://webapi';

  constructor(private http: HttpClient) { }

  // Método para obter todos os clientes
  getClientes(): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(`${this.apiUrl}/api/v1/cliente`);
  }

  // Método para obter um cliente pelo ID
  getCliente(id: number): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(`${this.apiUrl}/api/v1/cliente/${id}`);
  }

  // Método para criar um novo cliente
  createCliente(cliente: Cliente): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(`${this.apiUrl}/api/v1/cliente`, cliente);
  }

  // Método para atualizar um cliente existente
  updateCliente(id: number, client: Cliente): Observable<ApiResponse> {
    return this.http.put<ApiResponse>(`${this.apiUrl}/api/v1/cliente/${id}`, client);
  }

  // Método para excluir um cliente
  deleteCliente(id: number): Observable<ApiResponse> {
    return this.http.delete<ApiResponse>(`${this.apiUrl}/api/v1/cliente/${id}`);
  }
}
