import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Validators } from '@angular/forms';
import { CaseSearch } from '../enums/case-search.enum';
import { ICompare } from '../interfaces/icompare';
import { StringMatchService } from './string-match.service';

@Component({
  selector: 'app-string-match',
  templateUrl: './string-match.component.html',
  styleUrls: ['./string-match.component.css']
})
export class StringMatchComponent {

  public noMatchFound : boolean = false;
  public matchIndexs =[];
 // public fullString: string;
  public subString: string = '';
  public caseSearchCheck: CaseSearch;
  public compare: ICompare = { inputString: '', subString: '', matchedWords: [], caseSearch: CaseSearch.MatchCase };
  public inputStringTouched: boolean = false;
  public subStringTouched: boolean = false;
  public inputString: string = '';
  public isExceedSearchLength: boolean = false;
  public isDisabledSubmit: boolean = false;
  public isDisabledInputString: boolean = false;
  public isDisabledSubString: boolean = false;
  public validPost: boolean = false;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private stringMatchService: StringMatchService) {

  }

  
  public keyupInputString() {
    
    this.inputStringTouched = true;
    this.validatePost();
  }

  public keyupSubString() {
    
    this.subStringTouched = true;

    if (this.subString.length > this.inputString.length) {
      this.isExceedSearchLength = true;
      this.isDisabledSubmit = true;
      
    }
    else {
      this.isExceedSearchLength = false;
      this.isDisabledSubmit = false;
    }

    this.validatePost();
  }

  public resetValues() {
    this.isDisabledSubmit = false;
    this.isDisabledInputString = false;
    this.isDisabledSubString = false;
    this.inputString = '';
    this.subString = '';
    this.inputStringTouched = false;
    this.subStringTouched = false;
    this.noMatchFound = false;
    this.matchIndexs = [];

    return;
  }

  public validatePost() {
    this.validPost = false;

    if (this.inputString && this.inputStringTouched) {      
      if (this.subString && this.subStringTouched) {
        if (!this.isExceedSearchLength) {
          this.validPost = true;

        }
      }
    }
    
    console.log("validate post method is -" + this.validPost);
  }

  public searchMatchingValues(inputString: string, subString: string, caseSearchCheck: CaseSearch) {    
   
    this.compare.inputString = inputString;
    this.compare.subString = subString;

    if (caseSearchCheck) {
      this.compare.caseSearch = CaseSearch.IgnoreCase;
    }
    else {
      this.compare.caseSearch = CaseSearch.MatchCase;
    }    
   
    this.stringMatchService.post(this.compare).subscribe(result => {
      if (result.matchedWords && result.matchedWords.length) {
        this.noMatchFound = false;
        this.matchIndexs = result.matchedWords;        
      }
      else {
        this.noMatchFound = true;
        
      }
      this.isDisabledSubmit = true;
      this.isDisabledInputString = true;
      this.isDisabledSubString = true;
      
      return Object.keys(this.matchIndexs)
    });
  }
}
