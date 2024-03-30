import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { studentList } from '../student-list/student-list.component';
import { StudentServiceService } from '../student-service.service';

@Component({
  selector: 'app-student-edit',
  templateUrl: './student-edit.component.html',
  styleUrls: ['./student-edit.component.css']
})
export class StudentEditComponent implements OnInit {

  constructor(private route: ActivatedRoute,private studentServiceService: StudentServiceService, private router: Router) { }
  studentDetailsViewModel: studentList = {
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
    this.route.paramMap.subscribe({
      next: (params) => {
        var studentID = params.get('studentID');

        if (studentID) {
          //call api
          this.studentServiceService.GetStudentByID(Number(studentID))
            .subscribe({
              next: (response) => {
                this.studentDetailsViewModel = response;
              }
            })
        }
      }
    })
  }

  UpdateStudent() {
    if (confirm('Updated Successfully')) {
      this.studentServiceService.UpdateStudent(this.studentDetailsViewModel.studentID, this.studentDetailsViewModel)
        .subscribe({
          next: (response) => {
            this.router.navigate(['students']);
          }
        })
    }
  }

}
