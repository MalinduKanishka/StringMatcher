import { CaseSearch } from "../enums/case-search.enum";
import { IMatchWords } from "./imatch-words";

export interface ICompare {
  inputString: string;
  subString: string;
  matchedWords: IMatchWords[];
  caseSearch: CaseSearch;
}
