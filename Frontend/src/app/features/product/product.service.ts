import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductInterface } from './product.interface';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  #apiUrl = 'http://localhost:5253';
  #httpClient = inject(HttpClient);

  getProducts(): Observable<ProductInterface[]> {
    return this.#httpClient.get<ProductInterface[]>(`${this.#apiUrl}/products`);
  }

  getProduct(id: number): Observable<ProductInterface> {
    return this.#httpClient.get<ProductInterface>(`${this.#apiUrl}/products/${id}`);
  }

  createProduct(product: ProductInterface): Observable<ProductInterface> {
    // Asegurarse de que el ID no se envíe al crear
    const { id, ...productWithoutId } = product;
    return this.#httpClient.post<ProductInterface>(`${this.#apiUrl}/products`, productWithoutId);
  }

  updateProduct(product: ProductInterface): Observable<ProductInterface> {
    return this.#httpClient.put<ProductInterface>(`${this.#apiUrl}/products/${product.id}`, product);
  }

  deleteProduct(id: number): Observable<void> {
    return this.#httpClient.delete<void>(`${this.#apiUrl}/products/${id}`);
  }
}
