# Dodge The Bear - Unity ML-Agents Reinforcement Learning Project

## Overview
This repository contains a reinforcement learning project using Unity ML-Agents. In this project, an agent in the form of a fox attempts to dodge incoming bears by moving left and right. The bears spawn randomly and move towards the fox's direction.

## Approach
The project was approached with the following methodology:
- **Problem Definition**: Identified the objective of the agent and environment. Determined the goal of the fox agent to dodge incoming bears.
- **Environment Design**: Created a Unity environment where the fox agent and bears interact. Configured movement and spawning mechanics for bears.
- **Agent Behavior**: Developed the fox agent's behavior to navigate and dodge bears by moving left and right within the environment.
- **Reinforcement Learning Setup**: Utilized Unity ML-Agents toolkit to implement the reinforcement learning setup for training the fox agent.
- **Hyperparameter Tuning**: Adjusted the YAML configuration (`DodgeTheBear.yaml`) to fine-tune learning rate and epoch settings for optimal learning.
- **Training and Evaluation**: Trained the agent using the configured environment and monitored its performance over episodes.
- **TensorBoard Visualization**: Integrated TensorBoard to visualize training metrics such as episode length, loss function, and cumulative rewards.
- **Analysis and Improvement**: Analyzed the training results, iterated on the model, environment, or hyperparameters to improve the agent's performance.

## Project Details
- **Agent**: The agent is controlled to dodge the incoming bears.
- **Bears**: Bears spawn randomly and move forward towards the fox.
- **YAML Configuration**: The project is configured using the `DodgeTheBear.yaml` file, which modifies the learning rate and epoch settings.
- **TensorBoard Graphs**:
  - Episode Length: ![Episode Length Graph](tensorboard/episode%20length.png)
  - Loss Function: ![Loss Function Graph](tensorboard/loss%20function.png)
  - Cumulative Reward: ![Cumulative Reward Graph](tensorboard/cumulative%20reward.png)
- **Agent in Action**:
  - The `agent in action/` folder contains a video (45mins into training) showcasing the agent's behavior during training.
