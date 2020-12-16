import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { SignupComponent } from './auth/signup/signup.component';
import { SigninComponent } from './auth/signin/signin.component';
import { CategoryCreateComponent } from './components/category/category-create/category-create.component';
import { CategoryListComponent } from './components/category/category-list/category-list.component';
import { CategoryEditComponent } from './components/category/category-edit/category-edit.component';
import { CategoryResolver } from './core/resolvers/CategoryResolver';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: HomeComponent },
  { path: 'signUp', component: SignupComponent },
  { path: 'signIn', component: SigninComponent },
  {
    path: 'category', children: [
      { path: '', component: CategoryListComponent },
      { path: 'all', component: CategoryListComponent },
      { path: 'create', component: CategoryCreateComponent },
      {
        path: 'edit/:id', component: CategoryEditComponent,
        resolve:
        {
          category: CategoryResolver
        }
      },
    ]
  }

]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule {
  
}
