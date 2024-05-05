export interface Todo {
  id: number;
  name: string;
  description: string;
}

export interface TodoDetails extends Todo {
  row: number;
  factorial: number;
}
