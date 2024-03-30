import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { studentList } from './student-list/student-list.component';

@Injectable({
  providedIn: 'root'
})
export class StudentServiceService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }
  getAllStudents(): Observable<studentList[]> {
    debugger;
    return this.http.get<studentList[]>(this.baseApiUrl + '/api/Student/GetAllStudent');
  }

  AddStudent(studentViewModel: studentList): Observable<studentList> {
    debugger;
    return this.http.post<studentList>(this.baseApiUrl + '/api/Student/InsertStudent', studentViewModel);
  }

  GetStudentByID(StudentID: number): Observable<studentList> {
    debugger;
    return this.http.get<studentList>(this.baseApiUrl + '/api/Student/GetStudent/?studentID=' + StudentID);
  }

  UpdateStudent(StudentID: number, studentViewModel: studentList): Observable<studentList> {
    return this.http.put<studentList>(this.baseApiUrl + '/api/Student/UpdateStudent/?studentID=' + StudentID, studentViewModel);
  }
  DeleteStudent(StudentID: number): Observable<studentList> {
    return this.http.delete<studentList>(this.baseApiUrl + '/api/Student/DeleteStudent/?studentID=' + StudentID);
  }

}
