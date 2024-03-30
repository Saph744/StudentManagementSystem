import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Timestamp } from 'rxjs';
import { StudentServiceService } from '../student-service.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {
  studentName = '';
  constructor(private studentServiceService: StudentServiceService, private router: Router) { }
  students: studentList[] = [];


  ngOnInit(): void {
    this.getStudents();
  }
  getStudents() {
    this.studentServiceService.getAllStudents()
      .subscribe({
        next: (students) => {
          this.students = students;
        },
        error: (response) => {
          console.log(response);
        }
      });
  }

  Search() {
    if (this.studentName == "") {
      this.ngOnInit();
    } else {
      this.students = this.students.filter(res => {
        return res.name.toLocaleLowerCase().match(this.studentName.toLocaleLowerCase());
      })
    }
  }

  confirmDelete(studentID: number) {
    if (confirm('Are you sure you want to delete this student?')) {
      this.deleteStudent(studentID);
    }
  }

  deleteStudent(studentID: number) {
    this.studentServiceService.DeleteStudent(studentID)
      .subscribe({
        next: (response) => {
          // Reload students after successful deletion
          this.getStudents();
          this.router.navigate(['students']);
        },
        error: (error) => {
          console.log(error);
        }
      });
  }

}

export interface studentList {
  studentID: number;
  birthDate: Date | null;
  address: string | null;
  name: string;
  mobile: string;
  email: string | null;
  year: Date | null;
  schoolCollege: string | null;
  percentage: string | null;
  guardianName: string | null;
  guardianType: string | null;
}
