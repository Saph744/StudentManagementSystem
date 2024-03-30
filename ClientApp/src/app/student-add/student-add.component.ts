import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { studentList } from '../student-list/student-list.component';
import { StudentServiceService } from '../student-service.service';

@Component({
  selector: 'app-student-add',
  templateUrl: './student-add.component.html',
  styleUrls: ['./student-add.component.css']
})
export class StudentAddComponent implements OnInit {

  constructor(private studentServiceService: StudentServiceService, private router: Router, private http: HttpClient) { }

  studentViewModel: studentList = {
    studentID: 0,
    birthDate: null,
    address: '',
    name: '',
    mobile: '',
    email: '',
    year: null,
    schoolCollege: '',
    percentage: '',
    guardianName: '',
    guardianType: '',
  }

  ngOnInit(): void {
  }

  InsertStudent() {
    debugger;
      this.studentServiceService.AddStudent(this.studentViewModel)
        .subscribe({
          next: (studentList) => {
            this.router.navigate(['students']);
          },
          error: (error) => {
            console.error('Error adding student:', error);
          }
        });
   }

}
