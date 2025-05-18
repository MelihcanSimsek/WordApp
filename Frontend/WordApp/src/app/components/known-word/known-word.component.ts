import { Component, OnInit } from '@angular/core';
import { GetAllKnownWordsQueryResponse } from '../../models/queries/getall/known/getAllKnownWordsQueryResponse';
import { WordService } from '../../services/word.service';
import { NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-known-word',
  imports: [NgFor,NgIf],
  templateUrl: './known-word.component.html',
  styleUrl: './known-word.component.css'
})
export class KnownWordComponent implements OnInit {
  knownWords: GetAllKnownWordsQueryResponse[] = [];
  checkedWords: GetAllKnownWordsQueryResponse[] = [];
  hasData: boolean = false;
  isTranslated: boolean = false;
  constructor(private wordService: WordService) { }

  ngOnInit(): void {
    this.getAllKnownWords();
  }

  getAllKnownWords() {
    this.wordService.GetAllKnownWords().subscribe(
      (response: GetAllKnownWordsQueryResponse[]) => {
        this.knownWords = response;
        this.hasData = this.knownWords.length > 0;
      },
      (error) => {
        console.error('Error fetching known words:', error);
      }
    );
  }

  UpdateChecked(id: string) {
    const request = {
      id: id
    };

    this.wordService.UpdateChecked(request).subscribe(
      (response) => {
        this.checkedWords.push(this.knownWords.find(word => word.id === id)!);
        this.knownWords.splice(this.knownWords.findIndex(word => word.id === id), 1);
        this.hasData = this.knownWords.length > 0;
        this.isTranslated = false;
      },
      (error) => {
        console.error('Error updating word checked time:', error);
      }
    );
  }

   ChangeIsTranslated() {
    this.isTranslated = !this.isTranslated;
  }
 
}
