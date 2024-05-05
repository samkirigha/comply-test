import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Todo, TodoDetails } from './todo.model';

@Injectable()
export class TodoService {

  constructor(private http: HttpClient) { }

  getTodos(): Observable<TodoDetails[]> {
    return this.http.get<TodoDetails[]>(environment.API);
  }

  getFactorial(): Observable<TodoDetails[]> {
    return this.http.get<TodoDetails[]>(environment.API + 'Factorial');
  }

  addTodo(todo: Todo): Observable<Todo> {
    return this.http.post<Todo>(environment.API, todo);
  }
}
