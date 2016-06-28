groupDataFunction <- function(filename)
{
        #Read Json Data
        library(jsonlite)
        #inputData <- fromJSON("output10json.txt")
        inputData <- fromJSON(filename)

        #Merged Data by group 
        outputmergeddata <- data.frame(matrix(nrow=0,ncol=8))
        colnames(outputmergeddata) <- c("Text","Label_No","Label", "Position_top", "Position_left", "Size_height", "Size_width", "Group_No") 


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
                                newRow <- data.frame(Text = words$Text[len],
                                                     Position_top = words$Rectangle$Top[len] , 
                                                     Position_left= words$Rectangle$Left[len] , 
                                                     Size_height = words$Rectangle$Height[len], 
                                                     Size_width = words$Rectangle$Width[len], 
                                                     Label = "", 
                                                     Group_No = Group_number,
                                                     Label_No = "")
                                #Group words on same line with Space as seperator
                                if(group_word == "")
                                {
                                        group_word <- newRow$Text       
                                }
                                else
                                {
                                        group_word <- paste(group_word,newRow$Text,sep = " ")
                                }
                                #Check Email Address Format
                                if(length(grep("(@)",newRow$Text)) > 0 )
                                {
                                        newRow$Label <- paste("EmailAddress1")
                                        group_label <- newRow$Label
                                        group_label_no <- "9"
                                }
                                #Check Phone Number Format
                                if(length(grep("^\\s*(?:\\+?(\\d{1,3}))?[-. (]*(\\d{3})[-. )]*(\\d{3})[-. ]*(\\d{4})(?: *x(\\d+))?\\s*$",newRow$Text)) > 0)
                                {
                                        newRow$Label <- paste("PhoneNumber1") 
                                        group_label <- newRow$Label
                                        group_label_no <- "2"
                                }
                        }
                        newmergedRow <- data.frame(Text = group_word, Label = group_label,
                                                   Group_No = Group_number, Label_No = group_label_no,
                                                   Position_top = inputData$Regions$Lines[[region_count]]$Rectangle$Top[word_count],
                                                   Position_left = inputData$Regions$Lines[[region_count]]$Rectangle$Left[word_count], 
                                                   Size_height = inputData$Regions$Lines[[region_count]]$Rectangle$Height[word_count], 
                                                   Size_width = inputData$Regions$Lines[[region_count]]$Rectangle$Width[word_count] )
                        outputmergeddata <- rbind(outputmergeddata,data.frame(newmergedRow))
                        Group_number <- Group_number + 1 
               }
        }
        return(outputmergeddata)
}
