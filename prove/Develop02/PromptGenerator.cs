using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today? And why? ",
        "What was the best part of my day?",
        "What was the strongest emotion i felt today? and why?? ",
        "If I had one thing i could do over today, what would it be? and why? ",
        "what is something I learned today?",
        "What did i feel spiritually today?",
        "how did i improve myself today?"
    };

    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
