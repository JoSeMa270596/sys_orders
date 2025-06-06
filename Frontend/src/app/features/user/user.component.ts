import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserInterface } from './user.interface';
import { UserService } from './user.service';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './user.component.html',
  styleUrl: './user.component.scss'
})
export class UserComponent {
  #userService = inject(UserService);

  users: UserInterface[] = [];
  newUser: UserInterface = { name: '', email: '' };
  editingUser: UserInterface | null = null;
  searchTerm: string = '';


  constructor() {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.#userService.getUsers().subscribe({
      next: (data) => {
        this.users = data;
      },
      error: (err) => {
        console.error('Error al cargar usuarios:', err);
        // Aquí podrías mostrar un mensaje de error al usuario
      }
    });
  }

  saveUser(): void {
    if (this.editingUser) {
      // Editar usuario existente
      this.#userService.updateUser(this.newUser).subscribe({
        next: (updatedUser) => {
          this.resetForm();
          this.loadUsers();
        },
        error: (err) => {
          console.error('Error al actualizar usuario:', err);
        }
      });
    } else {
      // Crear nuevo usuario
      this.#userService.createUser(this.newUser).subscribe({
        next: (createdUser) => {
          this.resetForm();
          this.loadUsers();
        },
        error: (err) => {
          console.error('Error al crear usuario:', err);
        }
      });
    }
  }

  editUser(user: UserInterface): void {
    this.editingUser = { ...user };
    this.newUser = { ...user };
  }

  deleteUser(id: number | undefined): void {
    if (id === undefined) {
      console.warn('No se puede eliminar al usuario: ID no definido.');
      return;
    }
    if (confirm('¿Estás seguro de que quieres eliminar este usuario?')) {
      this.#userService.deleteUser(id).subscribe({
        next: () => {
          this.users = this.users.filter(user => user.id !== id);
        },
        error: (err) => {
          console.error('Error al eliminar usuario:', err);
        }
      });
    }
  }

  cancelEdit(): void {
    this.resetForm();
  }

  resetForm(): void {
    this.newUser = { name: '', email: '' };
    this.editingUser = null;
  }
}
