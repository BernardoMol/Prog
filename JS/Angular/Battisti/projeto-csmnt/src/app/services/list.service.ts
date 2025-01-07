import { Injectable } from '@angular/core';
import { Animal } from '../InterfaceAnimal';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ListService {
  private apoUrl = 'http://localhost:3000/animals'
  constructor( private http: HttpClient) { }
  // geralmente usa para agrupar as requisições de API e as interações com o backend
  // remove(animals: Animal[],animal: Animal ){
  //   console.log('Ativando serviço')
  //   return animals.filter((a) => animal.name !== a.name)
  // }

  remove(idDoAnimal: number ){
    return this.http.delete<Animal[]>(`${this.apoUrl}/${idDoAnimal}`) // EXCLUINDO DO BANCO
  }
  getAll(): Observable<Animal[]> {
    return this.http.get<Animal[]>(this.apoUrl) // BUSCANDO TODOS OS DADOS DO BANCO
  }
  getItem(id: Number): Observable<Animal> {
    return this.http.get<Animal>(`${this.apoUrl}/${id}`) // BUSCANDO ELEMENTO ESPECIFICO DO BANCO
  }
}
