import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { HomeComponent } from './home/home.component';
import { UserLoggedGuard } from './guards/user.logged.guard';
import { CreateComponent } from './aviones/create/create.component';
import { ListComponent } from './aviones/list/list.component';

const routes: Routes = [
  {  path: "login", component: LoginComponent },
  {  path: "aviones/crear", component: CreateComponent, canActivate: [UserLoggedGuard] },
  {  path: "aviones/listado", component: ListComponent, canActivate: [UserLoggedGuard] },
  {  path: "home", component: HomeComponent},
  {  path: "**", component: NotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
