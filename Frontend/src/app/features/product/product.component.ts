import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ProductService } from './product.service';
import { ProductInterface } from './product.interface';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './product.component.html',
  styleUrl: './product.component.scss'
})
export class ProductComponent {
  #productService = inject(ProductService);

  products: ProductInterface[] = [];
  newProduct: ProductInterface = { name: '', price: 0, userId: 0 };
  editingProduct: ProductInterface | null = null;

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    this.#productService.getProducts().subscribe({
      next: (data) => {
        this.products = data;
        console.log('Productos cargados:', this.products);
      },
      error: (err) => {
        console.error('Error al cargar productos:', err);
      }
    });
  }

  saveProduct(): void {
    if (this.editingProduct) {
      // Editar producto existente
      this.#productService.updateProduct(this.newProduct).subscribe({
        next: (updatedProduct) => {
          this.resetForm();
          this.loadProducts();
        },
        error: (err) => {
          console.error('Error al actualizar producto:', err);
        }
      });
    } else {
      // Crear nuevo producto
      this.#productService.createProduct(this.newProduct).subscribe({
        next: (createdProduct) => {
          this.resetForm();
          this.loadProducts();
        },
        error: (err) => {
          console.error('Error al crear producto:', err);
        }
      });
    }
  }

  editProduct(product: ProductInterface): void {
    this.editingProduct = { ...product };
    this.newProduct = { ...product };
  }

  deleteProduct(id: number | undefined): void {
    if (id === undefined) {
      console.warn('No se puede eliminar el producto: el ID es indefinido.');
      return;
    }
    if (confirm('¿Estás seguro de que quieres eliminar este producto?')) {
      this.#productService.deleteProduct(id).subscribe({
        next: () => {
          this.products = this.products.filter(product => product.id !== id);
        },
        error: (err) => {
          console.error('Error al eliminar producto:', err);
        }
      });
    }
  }

  cancelEdit(): void {
    this.resetForm();
  }

   resetForm(): void {
    this.newProduct = { name: '', price: 0, userId: 0 };
    this.editingProduct = null;
  }
}
