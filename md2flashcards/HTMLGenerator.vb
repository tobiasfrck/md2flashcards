Imports System.Text.RegularExpressions

Public Class HTMLGenerator
    Public Sub createHTMLCards(cards As List(Of LearningCard), output_file As String)
        Dim html_cards As New List(Of String)
        html_cards.Add("<!DOCTYPE html><html lang='de'><style>:root {--main-color: rgb(88, 155, 255);--divider-color: rgba(255, 255, 255, 0.479);}body {height: 100%;margin-bottom: 0;margin-top: 0;background-color: rgb(35, 35, 35);font-family: sans-serif;}.all {align-items: center;text-align: left;font-size: large;background-color: rgb(48, 45, 54);border: none;outline: none;border-radius: 17px;width: auto;height: 100%;margin-left: auto;margin-right: auto;max-width: 70rem;}.LearningCard {height: 100%;}.titel {margin-top: 5px;color: rgb(255, 255, 255);text-align: center;outline: none;font-size: 36px;border-bottom: 5px Solid #fff;padding-bottom: 10px;padding-top: 10px;width: 100%;background-color: rgb(48, 45, 54);border-radius: 17px 17px 0 0;}.titlefix {background-color: rgb(35, 35, 35);position: sticky;margin-top: 0;padding-top: 5px;top: 0;}.content {color: rgb(255, 255, 255);border: none;text-align: left;outline: none;padding-left: 60px;padding-right: 60px;height: 100%;bottom: 0;font-size: 22px;}.noanswer {padding-bottom: 10px;border-radius: 17px;}.link {color: rgb(221, 1, 255);}p {overflow-wrap: break-word;line-height: 100%;}.prev,.next {cursor: pointer;position: relative;width: auto;padding: 5px;margin-top: -22px;color: white;font-weight: bold;font-size: 30px;padding: 10px 20px;border-radius: 0 6px 6px 0;user-select: none;z-index: 10;}.prevnext-wrapper {max-width: 70rem;margin-left: auto;margin-right: auto;width: 100%;position: fixed;top: 50%;display: flex;justify-content: space-between;}.reveal {background-color: rgb(40, 40, 40);font-weight: bold;font-size: 30px;border-radius: 0 0 17px 17px;z-index: 2;}.revealfix {z-index: 1;cursor: pointer;align-items: center;position: sticky;margin-left: auto;margin-right: auto;margin-bottom: auto;margin-top: auto;color: rgb(255, 255, 255);user-select: none;width: 100%;bottom: 0;text-align: center;padding-bottom: 10px;background-color: rgb(35, 35, 35);}.next {border-radius: 6px 0 0 6px;}.prev:hover,.next:hover {transition: 0.6s ease;background-color: rgba(0, 0, 0, 0.8);}.reveal:hover {transition: 0.6s ease;background-color: rgb(29, 29, 29);}.rev:active {transition: 0.2s ease;background-color: rgba(0, 0, 0);color: rgb(0, 158, 5);}.hide:active {transition: 0.2s ease;background-color: rgba(0, 0, 0);color: red;}</style><style media='print'>@page {size: A4;margin: 0;}.prev,.next,.reveal {display: none;}.card,.answer {background-color: white;color: black;}hr {color: black;}</style><head><title>LearningCard</title></head><body onbeforeprint='changePrintLayout()'><div class='all'><div class='prevnext-wrapper'><a class='prev' onclick='previousSlide()'>❮</a><a class='next' onclick='nextSlide()'>❯</a></div>".Replace("'", Chr(34)))
        For Each card As LearningCard In cards
            html_cards.AddRange(card2HTML(card))
        Next
        html_cards.AddRange(card2HTML(cards.Last()))
        html_cards.Add("<div class=" & Chr(34) & "revealfix" & Chr(34) & ">")
        html_cards.Add("<div class=" & Chr(34) & "revealfix" & Chr(34) & "><a onclick=" & Chr(34) & "revealAnswer()" & Chr(34) & " class=" & Chr(34) & "reveal" & Chr(34) & ">Reveal</a></div>")
        html_cards.Add("</div></div></body>")
        html_cards.Add("<script>    let slideIndex = 1;    let learnCards = document.getElementsByClassName('LearningCard');    let cards = document.getElementsByClassName('card');    let answers = document.getElementsByClassName('answer');    showSlides(slideIndex);    document.addEventListener('keydown', function (event) {        if (event.keyCode == 39) {            nextSlide();        }        if (event.keyCode == 37) {            previousSlide();        }    });    function changePrintLayout() {    }    function revealAnswer() {        let rev = document.getElementsByClassName('reveal')[0];        let ans = learnCards[slideIndex - 1].getElementsByClassName('answer')[0];        if (ans == undefined) {            console.log('No answer for card: ' + slideIndex);            return;        }        if (ans.style.display == 'none') {            ans.style.display = 'block';            rev.innerHTML = 'Hide';            rev.classList.add('hide');            rev.classList.remove('rev');            cards[slideIndex - 1].style.display = 'none';        } else {            ans.style.display = 'none';            rev.innerHTML = 'Reveal';            rev.classList.remove('hide');            rev.classList.add('rev');            cards[slideIndex - 1].style.display = 'block';        }    }    function nextSlide() {        showSlides(slideIndex += 1);    }    function previousSlide() {        showSlides(slideIndex -= 1);    }    function showSlides() {                let rev = document.getElementsByClassName('reveal')[0];        let revfix = document.getElementsByClassName('revealfix')[0];        if (slideIndex > cards.length - 1) { slideIndex = 1 };        if (slideIndex < 1) { slideIndex = cards.length - 1};        for (let answer of answers) {            answer.style.display = 'none';        }        for (let slide of cards) {            slide.style.display = 'none';        }        cards[slideIndex - 1].style.display = 'block';        let ans = learnCards[slideIndex - 1].getElementsByClassName('answer')[0];        if (ans == undefined) {            rev.style.display = 'none';            revfix.style.display = 'none';                    } else {            revfix.style.display = 'block';            rev.style.display = 'block';            rev.innerHTML = 'Reveal';            rev.classList.add('rev');        }    }</script>".Replace("'", Chr(34)))
        html_cards.Add("</html>")
        createFile(output_file, html_cards)
    End Sub

    Private Function card2HTML(card As LearningCard) As List(Of String)
        Dim output As New List(Of String)
        output.Add("<div class=" & Chr(34) & "LearningCard" & Chr(34) & ">")
        output.Add("<div class=" & Chr(34) & "card" & Chr(34) & ">")
        output.Add("<div class=" & Chr(34) & "titlefix" & Chr(34) & ">")
        output.Add("<h1 class=" & Chr(34) & "titel" & Chr(34) & ">" & card.getTitel() & "</h1></div>")
        output.Add("<div class=" & Chr(34) & "content" & Chr(34) & ">")
        For Each line As String In card.getFrontContent()
            Dim modline As String = mdline2HTML(cleanIncompatible(line))
            output.Add("<p>" + modline + "</p>")
        Next

        output.Add("</div></div>")

        output.Add("<div class=" & Chr(34) & "answer" & Chr(34) & ">")
        output.Add("<div class=" & Chr(34) & "titlefix" & Chr(34) & ">")
        output.Add("<h1 class=" & Chr(34) & "titel" & Chr(34) & ">" + "Antwort</h1></div>")
        output.Add("<div class=" & Chr(34) & "content" & Chr(34) & ">")

        For Each line As String In card.getBackContent()
            Dim modLine = mdline2HTML(cleanIncompatible(line))
            output.Add("<p>" + modLine + "</p>")
        Next

        output.Add("</div></div></div>")
        Return output
    End Function

    Private Function cardNOANSWER2HTML(card As LearningCard) As List(Of String)
        Dim output As New List(Of String)
        output.Add("<div class=" & Chr(34) & "LearningCard" & Chr(34) & ">")
        output.Add("<div class=" & Chr(34) & "card" & Chr(34) & ">")
        output.Add("<div class=" & Chr(34) & "titlefix" & Chr(34) & ">")
        output.Add("<h1 class=" & Chr(34) & "titel" & Chr(34) & ">" & card.getTitel() & "</h1></div>")
        output.Add("<div class=" & Chr(34) & "content" & Chr(34) & ">")
        For Each line As String In card.getFrontContent()
            Dim modline As String = mdline2HTML(cleanIncompatible(line))
            output.Add("<p>" + modline + "</p>")
        Next

        output.Add("</div></div></div>")
        Return output
    End Function

    Private Function mdline2HTML(line As String) As String
        Dim m As Match
        Dim front As String = ""
        Dim back As String = ""
        'heading and ignore heading 1
        If (line.StartsWith("#")) Then
            Dim heading_level = 1
            While (line.Chars(heading_level) = "#")
                heading_level += 1
            End While
            Debug.WriteLine("Heading level: " & heading_level.ToString & " found in line: " & line)
            front = "<h" + heading_level.ToString() & ">"
            line = line.Substring(heading_level + 1)
            back = "</h" + heading_level.ToString() & ">"
        ElseIf (line.StartsWith("- ") Or line.StartsWith("* ") Or line.StartsWith("+ ")) Then
            Debug.WriteLine("Unordered List found in line: " & line)
            line = "<li>" & line.Substring(2) & "</li>"
        End If

        ' inline-link
        m = Regex.Match(line, "\[(.*?)\]\((.*?)\)")
        If (m.Success) Then
            Dim link As String = m.Value
            Dim url As String = m.Groups(2).Value
            Dim text As String = m.Groups(1).Value
            Debug.WriteLine("Link found: " & link & " -> " & url & " -> " & text)
            line = line.Replace(link, "<a class=" & Chr(34) & "link" & Chr(34) & " href=" & Chr(34) & url & Chr(34) & ">" & text & "</a>")
        End If

        'inline code
        m = Regex.Match(line, "`(.*?)`")
        If (m.Success) Then
            Dim code As String = m.Value
            Dim text As String = m.Groups(1).Value
            Debug.WriteLine("Code found: " & code & " -> " & text)
            line = line.Replace(code, "<code>" & text & "</code>")
        End If

        'bold
        m = Regex.Match(line, "\*\*(.*?)\*\*")
        If (m.Success) Then
            Dim bold As String = m.Value
            Dim text As String = m.Groups(1).Value
            Debug.WriteLine("Bold found: " & bold & " -> " & text)
            line = line.Replace(bold, "<b>" & text & "</b>")
        End If

        'italic
        m = Regex.Match(line, "\*(.*?)\*")
        If (m.Success) Then
            Dim italic As String = m.Value
            Dim text As String = m.Groups(1).Value
            Debug.WriteLine("Italic found: " & italic & " -> " & text)
            line = line.Replace(italic, "<i>" & text & "</i>")
        End If

        'strikethrough
        m = Regex.Match(line, "~~(.*?)~~")
        If (m.Success) Then
            Dim strikethrough As String = m.Value
            Dim text As String = m.Groups(1).Value
            Debug.WriteLine("Strikethrough found: " & strikethrough & " -> " & text)
            line = line.Replace(strikethrough, "<s>" & text & "</s>")
        End If

        Return front & line & back
    End Function

    Public Sub createFile(path As String, content As List(Of String))
        Dim output As String = content.Aggregate("", Function(current, line) current + line + vbCrLf)

        Try
            My.Computer.FileSystem.WriteAllText(path, output, False)
        Catch ex As Exception
            Debug.WriteLine("[FILE ERROR]: While writing file: " + ex.Message)
        End Try
    End Sub
    Public Function cleanIncompatible(ByVal line As String) As String
        If (line.StartsWith("# ")) Then
            line = line.Substring(2)
        End If
        Return line
    End Function

    Public Sub createHTMLCardsWithNoAnswer(cards As List(Of LearningCard), output_file As String)
        Dim html_cards As New List(Of String)
        html_cards.Add("<!DOCTYPE html><html lang='de'><style>:root {--main-color: rgb(88, 155, 255);--divider-color: rgba(255, 255, 255, 0.479);}body {height: 100%;margin-bottom: 0;margin-top: 0;background-color: rgb(35, 35, 35);font-family: sans-serif;}.all {align-items: center;text-align: left;font-size: large;background-color: rgb(48, 45, 54);border: none;outline: none;border-radius: 17px;width: auto;height: 100%;margin-left: auto;margin-right: auto;max-width: 70rem;}.LearningCard {height: 100%;}.titel {margin-top: 5px;color: rgb(255, 255, 255);text-align: center;outline: none;font-size: 36px;border-bottom: 5px Solid #fff;padding-bottom: 10px;padding-top: 10px;width: 100%;background-color: rgb(48, 45, 54);border-radius: 17px 17px 0 0;}.titlefix {background-color: rgb(35, 35, 35);position: sticky;margin-top: 0;padding-top: 5px;top: 0;}.content {color: rgb(255, 255, 255);border: none;text-align: left;outline: none;padding-left: 60px;padding-right: 60px;height: 100%;bottom: 0;font-size: 22px;}.noanswer {padding-bottom: 10px;border-radius: 17px;}.link {color: rgb(221, 1, 255);}p {overflow-wrap: break-word;line-height: 100%;}.prev,.next {cursor: pointer;position: relative;width: auto;padding: 5px;margin-top: -22px;color: white;font-weight: bold;font-size: 30px;padding: 10px 20px;border-radius: 0 6px 6px 0;user-select: none;z-index: 10;}.prevnext-wrapper {max-width: 70rem;margin-left: auto;margin-right: auto;width: 100%;position: fixed;top: 50%;display: flex;justify-content: space-between;}.reveal {background-color: rgb(40, 40, 40);font-weight: bold;font-size: 30px;border-radius: 0 0 17px 17px;z-index: 2;}.revealfix {z-index: 1;cursor: pointer;align-items: center;position: sticky;margin-left: auto;margin-right: auto;margin-bottom: auto;margin-top: auto;color: rgb(255, 255, 255);user-select: none;width: 100%;bottom: 0;text-align: center;padding-bottom: 10px;background-color: rgb(35, 35, 35);}.next {border-radius: 6px 0 0 6px;}.prev:hover,.next:hover {transition: 0.6s ease;background-color: rgba(0, 0, 0, 0.8);}.reveal:hover {transition: 0.6s ease;background-color: rgb(29, 29, 29);}.rev:active {transition: 0.2s ease;background-color: rgba(0, 0, 0);color: rgb(0, 158, 5);}.hide:active {transition: 0.2s ease;background-color: rgba(0, 0, 0);color: red;}</style><style media='print'>@page {size: A4;margin: 0;}.prev,.next,.reveal {display: none;}.card,.answer {background-color: white;color: black;}hr {color: black;}</style><head><title>LearningCard</title></head><body onbeforeprint='changePrintLayout()'><div class='all'><div class='prevnext-wrapper'><a class='prev' onclick='previousSlide()'>❮</a><a class='next' onclick='nextSlide()'>❯</a></div>".Replace("'", Chr(34)))
        For Each card As LearningCard In cards
            html_cards.AddRange(cardNOANSWER2HTML(card))
        Next
        html_cards.AddRange(cardNOANSWER2HTML(cards.Last()))
        html_cards.Add("<div class=" & Chr(34) & "revealfix" & Chr(34) & ">")
        html_cards.Add("<div class=" & Chr(34) & "revealfix" & Chr(34) & "><a onclick=" & Chr(34) & "revealAnswer()" & Chr(34) & " class=" & Chr(34) & "reveal" & Chr(34) & ">Reveal</a></div>")
        html_cards.Add("</div></div></body>")
        html_cards.Add("<script>    let slideIndex = 1;    let learnCards = document.getElementsByClassName('LearningCard');    let cards = document.getElementsByClassName('card');    let answers = document.getElementsByClassName('answer');    showSlides(slideIndex);    document.addEventListener('keydown', function (event) {        if (event.keyCode == 39) {            nextSlide();        }        if (event.keyCode == 37) {            previousSlide();        }    });    function changePrintLayout() {    }    function revealAnswer() {        let rev = document.getElementsByClassName('reveal')[0];        let ans = learnCards[slideIndex - 1].getElementsByClassName('answer')[0];        if (ans == undefined) {            console.log('No answer for card: ' + slideIndex);            return;        }        if (ans.style.display == 'none') {            ans.style.display = 'block';            rev.innerHTML = 'Hide';            rev.classList.add('hide');            rev.classList.remove('rev');            cards[slideIndex - 1].style.display = 'none';        } else {            ans.style.display = 'none';            rev.innerHTML = 'Reveal';            rev.classList.remove('hide');            rev.classList.add('rev');            cards[slideIndex - 1].style.display = 'block';        }    }    function nextSlide() {        showSlides(slideIndex += 1);    }    function previousSlide() {        showSlides(slideIndex -= 1);    }    function showSlides() {                let rev = document.getElementsByClassName('reveal')[0];        let revfix = document.getElementsByClassName('revealfix')[0];        if (slideIndex > cards.length - 1) { slideIndex = 1 };        if (slideIndex < 1) { slideIndex = cards.length - 1};        for (let answer of answers) {            answer.style.display = 'none';        }        for (let slide of cards) {            slide.style.display = 'none';        }        cards[slideIndex - 1].style.display = 'block';        let ans = learnCards[slideIndex - 1].getElementsByClassName('answer')[0];        if (ans == undefined) {            rev.style.display = 'none';            revfix.style.display = 'none';                    } else {            revfix.style.display = 'block';            rev.style.display = 'block';            rev.innerHTML = 'Reveal';            rev.classList.add('rev');        }    }</script>".Replace("'", Chr(34)))
        html_cards.Add("</html>")
        createFile(output_file, html_cards)
    End Sub
End Class
