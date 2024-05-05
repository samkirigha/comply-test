import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import(
      './todo/todo-list/todo-list.component'
    ).then(c => c.TodoListComponent)
  }
];
