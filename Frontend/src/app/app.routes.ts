import { Routes } from '@angular/router';
import { UserComponent } from './features/user/user.component';
import { ProductComponent } from './features/product/product.component';
import { OrderComponent } from './features/order/order.component';

export const routes: Routes = [
  { path: 'user', component: UserComponent },
  { path: 'product', component: ProductComponent },
  { path: 'order', component: OrderComponent },
  { path: '', redirectTo: '/user', pathMatch: 'full' },
  { path: '**', redirectTo: '/user' }
];
