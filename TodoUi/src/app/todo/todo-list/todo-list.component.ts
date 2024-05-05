import { CommonModule } from '@angular/common';
import { Component, DestroyRef, inject, OnInit } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { HttpClientModule } from '@angular/common/http';
import { finalize } from 'rxjs';
import { DataViewModule } from 'primeng/dataview';
import { SkeletonModule } from 'primeng/skeleton';
import { ButtonModule } from 'primeng/button';
import { TagModule } from 'primeng/tag';
import { RatingModule } from 'primeng/rating';
import { DynamicDialogModule, DialogService } from 'primeng/dynamicdialog';
import { TodoService } from '../todo.service';
import { TodoDetails } from '../todo.model';
import { TodoAddComponent } from '../todo-add/todo-add.component';

@Component({
  selector: 'app-todo-list',
  standalone: true,
  imports: [
    CommonModule,
    HttpClientModule,
    DataViewModule,
    SkeletonModule,
    ButtonModule,
    TagModule,
    RatingModule,
    DynamicDialogModule
  ],
  templateUrl: './todo-list.component.html',
  styleUrl: './todo-list.component.scss',
  providers: [
    DialogService,
    TodoService
  ]
})
export class TodoListComponent implements OnInit {

  todos: TodoDetails[] = [];
  placeholders: Array<number> = Array(3);
  isLoading: boolean = false;
  layout: 'list' | 'grid' = 'list';

  private destroyRef$ = inject(DestroyRef);

  constructor(private todoService: TodoService, private dialogService: DialogService) { }

  ngOnInit(): void {
    this.getTodos();
  }

  getTodos(): void {
    this.isLoading = true;
    this.todoService.getTodos().pipe(
        takeUntilDestroyed(this.destroyRef$),
        finalize(() => this.isLoading = false)
      ).subscribe(todos => this.todos = todos);
  }

  getFactorial(): void {
    this.isLoading = true;
    this.todoService.getFactorial().pipe(
        takeUntilDestroyed(this.destroyRef$),
        finalize(() => this.isLoading = false)
      ).subscribe(todos => this.todos = todos);
  }

  addTodo(): void {
    this.dialogService.open(TodoAddComponent, {
      header: 'Add a Todo',
      width: '50vw',
      contentStyle: { overflow: 'auto' },
      breakpoints: {
        '960px': '75vw',
        '640px': '90vw'
      },
    })
    .onClose
    .pipe(takeUntilDestroyed(this.destroyRef$))
    .subscribe(todo => todo && this.todos.push(todo));

  }
}
