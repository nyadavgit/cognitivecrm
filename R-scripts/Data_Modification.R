#Read Json Data
library(jsonlite)
inputData <- fromJSON("output10json.txt")


#Create Data Frame
outputdata <- data.frame(matrix(nrow=0,ncol=8))
colnames(outputdata) <- c("Text","Label", "Position_top", "Position_left", "Size_height", "Size_width", "Line_No") 

Line_number = 1
for (words in inputData$Regions$Lines[[1]]$Words)
{
        l <- length(words$Text)
       for (len in 1:l)
       {
               newRow <- data.frame(Text = words$Text[len],Position_top = words$Rectangle$Top[len] , Position_left= words$Rectangle$Left[len] , Size_height = words$Rectangle$Height[len], Size_width = words$Rectangle$Width[len], Label = "", Line_No = Line_number )
               outputdata <- rbind(outputdata,data.frame(newRow))
       }
        Line_number <- Line_number + 1
}

