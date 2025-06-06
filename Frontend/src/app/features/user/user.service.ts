import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { UserInterface } from './user.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  #apiUrl = 'http://localhost:5253';
  #httpClient = inject(HttpClient);

  getUsers(): Observable<UserInterface[]> {
    return this.#httpClient.get<UserInterface[]>(`${this.#apiUrl}/users`);
  }

  getUser(id: number): Observable<UserInterface> {
    return this.#httpClient.get<UserInterface>(`${this.#apiUrl}/users/${id}`);
  }

  createUser(user: UserInterface): Observable<UserInterface> {
    const { id, ...userWithoutId } = user;
    return this.#httpClient.post<UserInterface>(`${this.#apiUrl}/users`, userWithoutId);
  }

  updateUser(user: UserInterface): Observable<UserInterface> {
    return this.#httpClient.put<UserInterface>(`${this.#apiUrl}/users/${user.id}`, user);
  }

  deleteUser(id: number): Observable<void> {
    return this.#httpClient.delete<void>(`${this.#apiUrl}/users/${id}`);
  }

}
