groupDataFunction <- function(filename)
{
        #Read Json Data
        library(jsonlite)
        library(stringr)
        #inputData <- fromJSON("output10json.txt")
        inputData <- fromJSON(filename)

        #Merged Data by group 
        outputmergeddata <- data.frame(matrix(nrow=0,ncol=18))
        colnames(outputmergeddata) <- c("Text","Label_No","Label",
                                        "Position_top", "Position_left", "Size_height", 
                                        "Size_width", "Group_No" , "Num_of_digits",
                                        "Num_of_chars" , "Num_of_symbols" , 
                                        "Num_email_char" , "Num_of_dash_char" , "Num_of_comma_char" , 
                                        "Num_www_str" , "Num_of_dots_Char" , "Num_of_brackets_char", "Word_Count")
        


        Group_number <- 1
        region_count <- 1
        for(region_count in 1:length(inputData$Regions$Lines))
        {
                for(word_count in  1:length(inputData$Regions$Lines[[region_count]]$Words))
                {
                        words <- inputData$Regions$Lines[[region_count]]$Words[[word_count]]
                
                        group_label <- ""
                        group_label_no <- ""
                        group_word <- ""
                        l <- length(words$Text)
                        for (len in 1:l)
                        {
                                #Group words on same line with Space as seperator
                                if(group_word == "")
                                {
                                        group_word <- words$Text[len]       
                                }
                                else
                                {
                                        group_word <- paste(group_word,words$Text[len],sep = " ")
                                }
                                #Check Email Address Format
                                if(length(grep("(@)",words$Text[len])) > 0 )
                                {
                                        group_label <- paste("EmailAddress1")
                                        group_label_no <- "8"
                                }
                                #Check Phone Number Format
                                if(length(grep("^\\s*(?:\\+?(\\d{1,3}))?[-. (]*(\\d{3})[-. )]*(\\d{3})[-. ]*(\\d{4})(?: *x(\\d+))?\\s*$",words$Text[len])) > 0)
                                {
                                        group_label <- paste("PhoneNumber1")
                                        group_label_no <- "2"
                                }
                        }
                        num_loc <- str_locate_all(group_word,"[0-9]+")[[1]]
                        num_loc[,2] <- num_loc[,2] - num_loc[,1] + 1
                        Num_digits <- sum(num_loc[,2])
                        
                        alphabets_loc <- str_locate_all(group_word,"[a-z,A-Z]+")[[1]]
                        alphabets_loc[,2] <- alphabets_loc[,2] - alphabets_loc[,1] + 1
                        Num_chars <- sum(alphabets_loc[,2])
                        
                        Num_and_alphabet_count <- str_locate_all(group_word,"[a-z,A-Z,0-9]+")[[1]]
                        Num_and_alphabet_count[,2] <- Num_and_alphabet_count[,2] - Num_and_alphabet_count[,1] + 1
                        Num_symbols = (str_count(group_word) - str_count(group_word," "))- sum(Num_and_alphabet_count[,2])
                        
                        Num_emailchar <- str_count(group_word,"@")
                        Num_dashchar <- str_count(group_word,"-")
                        Num_commachar <- str_count(group_word,",")
                        Num_wwwstr <- str_count(group_word,"www") + str_count(group_word,"WWW")
                        Num_dotsChar <- str_count(group_word,"\\.")
                        Num_bracketschar <- str_count(group_word,"\\(") + str_count(group_word,"\\)")
                        WordCount <- sapply(strsplit(as.character(group_word), " "), length)
                        newmergedRow <- data.frame(Text = group_word, Label = group_label,
                                                   Group_No = Group_number, Label_No = group_label_no,
                                                   Position_top = inputData$Regions$Lines[[region_count]]$Rectangle$Top[word_count],
                                                   Position_left = inputData$Regions$Lines[[region_count]]$Rectangle$Left[word_count], 
                                                   Size_height = inputData$Regions$Lines[[region_count]]$Rectangle$Height[word_count], 
                                                   Size_width = inputData$Regions$Lines[[region_count]]$Rectangle$Width[word_count] ,
                                                   Num_of_digits = Num_digits , Num_of_chars = Num_chars , Num_of_symbols = Num_symbols , 
                                                   Num_email_char = Num_emailchar , Num_of_dash_char = Num_dashchar  , Num_of_comma_char =  Num_commachar, 
                                                   Num_www_str = Num_wwwstr , Num_of_dots_Char = Num_dotsChar , Num_of_brackets_char = Num_bracketschar,
                                                   Word_Count = WordCount)
                        
                        outputmergeddata <- rbind(outputmergeddata,data.frame(newmergedRow))
                        Group_number <- Group_number + 1 
               }
        }
        return(outputmergeddata)
}
