import { Component, OnInit } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import { WordService } from '../../services/word.service';
import { GetAllDailyWordsQueryResponse } from '../../models/queries/getall/daily/getAllDailyWordsQueryResponse';
import { UpdateWordToKnownCommandRequest } from '../../models/commands/update/updateWordToKnownCommandRequest';
import { UpdateWordCheckedTimeCommandRequest } from '../../models/commands/update/updateWordCheckedTimeCommandRequest';


@Component({
  selector: 'app-daily-word',
  imports: [NgFor, NgIf],
  templateUrl: './daily-word.component.html',
  styleUrl: './daily-word.component.css'
})
export class DailyWordComponent implements OnInit {
  dailyWords: GetAllDailyWordsQueryResponse[] = [];
  checkedWords: GetAllDailyWordsQueryResponse[] = [];
  knownWords: GetAllDailyWordsQueryResponse[] = [];
  hasData: boolean = false;
  isTranslated: boolean = false;


  constructor(private wordService: WordService) { }

  ngOnInit(): void {
    this.getAllDailyWords();
  }

  getAllDailyWords() {
    this.wordService.GetAllDailyWords().subscribe(
      (response: GetAllDailyWordsQueryResponse[]) => {
        this.dailyWords = response;
        this.hasData = this.dailyWords.length > 0;
      },
      (error) => {
        console.error('Error fetching daily words:', error);
      }
    );
  }

  UpdateToKnown(id: string) {
    const request: UpdateWordToKnownCommandRequest = {
      id: id
    };

    this.wordService.UpdateToKnown(request).subscribe(
      (response) => {
        this.knownWords.push(this.dailyWords.find(word => word.id === id)!);
        this.dailyWords.splice(this.dailyWords.findIndex(word => word.id === id), 1);
        this.isTranslated = false;
        this.hasData = this.dailyWords.length > 0;
      },
      (error) => {
        console.error('Error updating word to known:', error);
      }
    );
  }


  UpdateChecked(id: string) {
    const request: UpdateWordCheckedTimeCommandRequest = {
      id: id
    };

    this.wordService.UpdateChecked(request).subscribe(
      (response) => {
        this.checkedWords.push(this.dailyWords.find(word => word.id === id)!);
        this.dailyWords.splice(this.dailyWords.findIndex(word => word.id === id), 1);
        this.isTranslated = false;
        this.hasData = this.dailyWords.length > 0;
      },
      (error) => {
        console.error('Error updating word to known:', error);
      }
    );
  }

 ChangeIsTranslated() {
    this.isTranslated = !this.isTranslated;
  }

}




