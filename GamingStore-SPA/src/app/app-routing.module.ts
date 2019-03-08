import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ItemsComponent } from 'src/app/items/items.component';
import { HomeComponent } from 'src/app/home/home.component';
import { ItemDetailComponent } from './item-detail/item-detail.component';
import { LoginComponent } from './login/login.component';
import { CartComponent } from './cart/cart.component';
import { SignupComponent } from './signup/signup.component';
import { AdminComponent } from 'src/app/admin/admin.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: "items/:id", component: ItemsComponent },
  { path: "itemDetail/:id", component: ItemDetailComponent },
  { path: "login", component: LoginComponent },
  { path: "cart", component: CartComponent },
  { path: "signup", component: SignupComponent },
  { path: "admin", component: AdminComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
